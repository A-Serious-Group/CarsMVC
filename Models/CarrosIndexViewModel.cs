namespace CarrosMVC.Models
{
    public class CarrosIndexViewModel
    {
        public List<Carro> Carros { get; set; }
        public List<Loja> Lojas { get; set; }
    }

    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}