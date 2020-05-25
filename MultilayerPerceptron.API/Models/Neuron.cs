namespace MultilayerPerceptron.API.Models
{
    public class Neuron
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public Layer Layer { get; set; }
        public int LayerId { get; set; }

    }
}