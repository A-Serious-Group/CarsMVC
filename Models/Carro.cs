// Models/Carro.cs
namespace CarrosMVC.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int MarcaId { get; set; }
        public required Marca Marca { get; set; }
        public int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }
    }
}
