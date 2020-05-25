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
        public void Add<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Network> GetNetwork(int id)
        {
            var network = await _context.Networks.Include(x => x.Layers).Where(x => x.Id == id).FirstOrDefaultAsync();

            return network;
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}