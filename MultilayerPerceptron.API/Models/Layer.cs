using System.Collections.Generic;

namespace MultilayerPerceptron.API.Models
{
    public class Layer
    {
        public int Id { get; set; }
        public IEnumerable<Neuron> Neurons { get; set; }
        public int LayerNumber { get; set; }
        public Network Network { get; set; }
        public int NeworkId { get; set; }

  
    }
}