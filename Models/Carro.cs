namespace CarrosMVC.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public int CarroceriaId { get; set; }
        public Carroceria? Carroceria { get; set; }
    }
}
