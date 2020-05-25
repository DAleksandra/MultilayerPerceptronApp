using System.Threading.Tasks;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public interface INetworkRepository
    {
        public Task<Network> GetNetwork(int id);
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        public Task<bool> SaveAll();
    }
}