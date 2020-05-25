using System.Threading.Tasks;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public interface ILayersRepository
    {
           Task<float> CalculateLayerOutput(Layer layer);
    }
}