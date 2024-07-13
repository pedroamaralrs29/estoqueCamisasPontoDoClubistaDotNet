namespace estoqueCamisasDotNet.Modelos;

public class Camisas
{
    public string NomeDoTime { get; set; }
    public string Tamanho { get; set; }
    public decimal Preco { get; set; }
    public int Id { get; set; }
    public string Genero { get; set; }


    public Camisas(string nomeDoTime, string tamanho, decimal preco, int id)
    {
        NomeDoTime = nomeDoTime;
        Tamanho = tamanho;
        Preco = preco;
        Id = id;
    }

    public override string ToString()
    {
        return $"Camisa do time: {NomeDoTime}, Tamanho: {Tamanho}, Preço: {Preco}, ID: {Id}";
    }
}
