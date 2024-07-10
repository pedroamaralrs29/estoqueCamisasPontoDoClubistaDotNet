using estoqueCamisasDotNet.Modelos;
using System.Threading.Channels;
using estoqueCamisasDotNet.Banco;
using System.ComponentModel.Design;


try
{
    var context = new estoqueDeCamisasDotNetContext();
    DAL<Camisas> camisasDal = new DAL<Camisas>(context);
    Console.Clear();

    bool continuar = true;
    while (continuar)
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Mostrar estoque");
        Console.WriteLine("2. Adicionar camisa");
        Console.WriteLine("3. Remover camisa");
        Console.WriteLine("4. Atualizar camisa");
        Console.WriteLine("5. Sair");

        Console.Write("\nDigite a opção desejada: ");
        string opcao = Console.ReadLine()!;

        switch (opcao)
        {
            case "1":
                MostrarEstoque(camisasDal);
                break;
            case "2":
                AdicionarCamisa(camisasDal);
                break;
            case "3":
                RemoverCamisa(camisasDal);
                break;
            case "4":
                AtualizarCamisa(camisasDal);
                break;
            case "5":
                continuar = false;
                break;
            default:
                Console.WriteLine("Opção inválida. Digite novamente.");
                break;


        }
    }
}
catch (Exception ex)
{

    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}

void AtualizarCamisa(DAL<Camisas> camisasDal)
{
    try
    {
        Console.WriteLine("Digite o ID do time que você deseja atualizar: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número inteiro válido.");
            Console.Write("ID: ");
        }

        var camisa = camisasDal.Listar().FirstOrDefault(c => c.Id == id);
        if (camisa != null) 
        { 
        Console.WriteLine("Digite o novo nome do time que deseja atualizar, ou deixe em branco caso não necessite de alteração: ");
        string nomeDoTime = Console.ReadLine();
        if(!string.IsNullOrEmpty(nomeDoTime))
        {
            camisa.NomeDoTime = nomeDoTime;
        }
        Console.WriteLine("Digite o novo tamanho da camisa que deseja atualizar, ou deixe em branco caso não necessite de alteração: ");
        string tamanhoDaCamisa = Console.ReadLine();
        if (!string.IsNullOrEmpty(tamanhoDaCamisa))
        {
            camisa.Tamanho = tamanhoDaCamisa;
        }
        Console.WriteLine("Digite o novo preço da camisa que deseja atualizar, ou deixe em branco caso não necessite de alteração: ");
        string precoDaCamisa = Console.ReadLine();
        if (!string.IsNullOrEmpty(nomeDoTime) && decimal.TryParse(precoDaCamisa, out decimal precoAtualizado))
        {
            camisa.Preco = precoAtualizado;
        }

        camisasDal.Atualizar(camisa);
        Console.WriteLine("Camisa atualizada com sucesso!");
        }else
        {
            Console.WriteLine("Camisa não encontrada");
        }

    }
    catch (Exception ex)
    {

        Console.WriteLine($"Erro ao atualizar a camisa: {ex.Message}");
    }

}

void MostrarEstoque(DAL<Camisas> camisasDal)
{
    try
    {
        var listaDeCamisas = camisasDal.Listar();
        Console.WriteLine("\n O estoque atual é: ");
        foreach (var camisa in listaDeCamisas)
        {
            Console.WriteLine(camisa);
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Erro ao mostrar o estoque: {ex.Message}");
    }
}

static void RemoverCamisa(DAL<Camisas> camisasDal)
{
    try
    {
        Console.WriteLine("Digite o ID da camisa que você deseja remover: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número inteiro válido.");
            Console.Write("ID: ");
        }
        var camisa = camisasDal.Listar().FirstOrDefault(c => c.Id == id);
        if(camisa != null)
        {
            camisasDal.Deletar(camisa);
            Console.WriteLine($"Camisa com o ID {id} removida do estoque");
        }
        else
        {
            Console.WriteLine($"\nCamisa com ID {id} não encontrada no estoque.");
        }

    }
    catch (Exception ex)
    {

        Console.WriteLine($"Erro ao remover a camisa: {ex.Message}");
    }
}

static void AdicionarCamisa(DAL<Camisas> camisasDal)
{
    try
    {
        Console.WriteLine("Digite o nome do time da camisa que você deseja adicionar: ");
        string nomeDoTime = Console.ReadLine()!;
        Console.WriteLine("Digite o tamanho da camisa que você deseja adicionar: ");
        string tamanhoDaCamisa = Console.ReadLine()!;
        Console.WriteLine("Digite o preço da camisa: ");
        decimal preco;
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Valor inválido. Digite um número válido.");
            Console.Write("Preço: ");
        }
        Console.Write("ID: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número inteiro válido.");
            Console.Write("ID: ");
        }

        Camisas novaCamisa = new Camisas(nomeDoTime, tamanhoDaCamisa, preco, id);
        camisasDal.Adcionar(novaCamisa);
        Console.WriteLine("\nCamisa adicionada com sucesso!");

    }
    catch (Exception ex)
    {

        Console.WriteLine($"Erro ao adicionar camisa: {ex.Message}");
    }
}

