using System.Collections.Generic;

namespace MultilayerPerceptron.API.Models
{
    public class Layer
    {
        public int Id { get; set; }
        public ICollection<Neuron> Neurons { get; set; }
        public int LayerNumber { get; set; }
        public Network Network { get; set; }
        public int NetworkId { get; set; }

  
    }
}