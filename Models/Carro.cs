public class Carro
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public int MarcaId { get; set; }
    public required Marca Marca { get; set; }
    public int ModeloId { get; set; }
    public required Modelo Modelo { get; set; }
}

// Models/Marca.cs
public class Marca
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required ICollection<Modelo> Modelos { get; set; }
}

// Models/Modelo.cs
public class Modelo
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public int MarcaId { get; set; }
    public required Marca Marca { get; set; }
}
