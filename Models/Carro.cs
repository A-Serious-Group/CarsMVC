public class Carro
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }
    public int ModeloId { get; set; }
    public Modelo Modelo { get; set; }
}
