using System.Threading.Tasks;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public class LayersRepository : ILayersRepository
    {
        public async Task<float> CalculateLayerOutput(Layer layer)
        {
            float output = 0;
            foreach (var neuron in layer.Neurons)
            {
                output += neuron.Value * neuron.Weight;
            }

            return output;
        }
    }
}