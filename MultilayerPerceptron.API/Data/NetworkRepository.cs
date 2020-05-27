using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public class NetworkRepository : INetworkRepository
    {
        public DataContext _context { get; }
        public NetworkRepository(DataContext context)
        {
            _context = context;

        }
        public T Add<T>(T entity) where T : class
        {
             return _context.Add(entity).Entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Network> GetNetwork(int id)
        {
            List<Layer> layers = new List<Layer>();

            var network = await _context.Networks.Include(x => x.Layers).Where(x => x.Id == id).FirstOrDefaultAsync();
            foreach(var layer in network.Layers) 
            {
                layers.Add(await GetLayer(layer.Id));
            } 

            network.Layers = layers;

            return network;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<Layer> GetLayer(int id)
        {
            var layer = _context.Layers.Where(x => x.Id == id).Include(x => x.Neurons).FirstOrDefaultAsync();

            return layer;
        }

        public Task<Layer> GetNeuron(int id)
        {
            var neuron = _context.Neurons.Where(x => x.Id == id).FirstOrDefaultAsync();

            return neuron;
        }
    }
}