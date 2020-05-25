namespace MultilayerPerceptron.API.Models
{
    public class ValuePair
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int NetworkId { get; set; }
        public Network Network { get; set; }
    }
}