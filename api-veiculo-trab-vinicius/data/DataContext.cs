
using api_veiculo_trab_vinicius.models;
using Microsoft.EntityFrameworkCore;

namespace api_veiculo_trab_vinicius.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        {
        }


        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
    }
}
