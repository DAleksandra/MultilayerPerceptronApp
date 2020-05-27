using System.Threading.Tasks;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public interface INetworkRepository
    {
        Task<Network> GetNetwork(int id);
        Task<Layer> GetLayer(int id);
        Task<Layer> GetNeuron(int id);
        T Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();


    }
}