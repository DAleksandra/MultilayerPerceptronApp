using System.Collections.Generic;

namespace MultilayerPerceptron.API.Models
{
    public class Network
    {
        public int Id { get; set; }
        public IEnumerable<Layer> Layers { get; set; }

    }
}