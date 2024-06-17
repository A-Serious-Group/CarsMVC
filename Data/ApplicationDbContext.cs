// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using CarrosMVC.Models;

namespace CarrosMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
    }
}
