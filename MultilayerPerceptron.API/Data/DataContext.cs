using Microsoft.EntityFrameworkCore;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Network> Networks { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Layer> Neurons { get; set; }
        public DbSet<ValuePair> ValuePairs { get; set; }
   
    }
}