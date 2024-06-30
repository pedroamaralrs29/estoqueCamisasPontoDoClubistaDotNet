namespace estoqueCamisasDotNet.Modelos;
internal class Estoque
{
    private List<Camisas> estoqueCamisas = new List<Camisas>();

    public void AdicionarCamisa(Camisas camisas)
    {
        estoqueCamisas.Add(camisas);
    }
}
