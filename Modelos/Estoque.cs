namespace estoqueCamisasDotNet.Modelos;
internal class Estoque
{
    private List<Camisas> estoqueCamisas = new List<Camisas>();

    public void AdicionarCamisa(Camisas camisas)
    {
        estoqueCamisas.Add(camisas);
    }

    public bool RemoverCamisa(int id)
    {
        Camisas camisaParaRemover = estoqueCamisas.FirstOrDefault(c => c.Id == id);
        if (camisaParaRemover != null)
        {
            estoqueCamisas.Remove(camisaParaRemover);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MostrarEstoque()
    {
        if(estoqueCamisas.Count == 0)
        {
            Console.WriteLine("O estoque está vazio.");
        }
        else
        {
            foreach (var camisa in estoqueCamisas)
            {
                Console.WriteLine(camisa);
            }
        }
    }
}
