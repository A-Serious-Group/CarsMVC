// Models/Marca.cs
namespace CarrosMVC.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required ICollection<Modelo> Modelos { get; set; }
    }
}
