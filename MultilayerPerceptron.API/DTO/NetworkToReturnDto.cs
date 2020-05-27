using System.Collections.Generic;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.DTO
{
    public class NetworkToReturnDto
    {
        public int Id { get; set; }
        public IEnumerable<Layer> Layers { get; set; }
    }
}