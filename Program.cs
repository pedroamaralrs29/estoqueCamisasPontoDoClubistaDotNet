using estoqueCamisasDotNet.Modelos;
using System.Threading.Channels;

Camisas AtleticoMG = new Camisas("Camisa Listrada", "M", 169.90, 123);
Camisas Cruzeiro = new Camisas("Camisa Azul", "G", 169.90, 1234);

Estoque estoquePontoDoClubista = new Estoque();
estoquePontoDoClubista.AdicionarCamisa(Cruzeiro);
estoquePontoDoClubista.AdicionarCamisa(AtleticoMG);

bool continuar = true;
while (continuar)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Mostrar estoque");
    Console.WriteLine("2. Adicionar camisa");
    Console.WriteLine("3. Remover camisa");
    Console.WriteLine("4. Sair");

    Console.Write("\nDigite a opção desejada: ");
    string opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            Console.WriteLine("\nEstoque Atual:");
            estoquePontoDoClubista.MostrarEstoque();
            break;
            case "2": 
                AdicionarCamisa(estoquePontoDoClubista);
            break;
            case "3":
            RemoverCamisa(estoquePontoDoClubista);
            break;
            case "4":
            continuar = false;
            break;
            default:
                Console.WriteLine("Opção inválida. Digite novamente.");
            break;


    }
}

static void RemoverCamisa(Estoque estoquePontoDoClubista)
{
    Console.WriteLine("Digite o ID da camisa que você deseja remover: ");
    int id;
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("ID inválido. Digite um número inteiro válido.");
        Console.Write("ID: ");
    }
    if (estoquePontoDoClubista.RemoverCamisa(id))
    {
        Console.WriteLine($"\nCamisa com ID {id} removida do estoque.");
    }
    else
    {
        Console.WriteLine($"\nCamisa com ID {id} não encontrada no estoque.");
    }
}

static void AdicionarCamisa(Estoque estoquePontoDoClubista)
{
    Console.WriteLine("Digite o nome do time da camisa que você deseja adicionar: ");
    string nomeDoTime = Console.ReadLine()!;
    Console.WriteLine("Digite o tamanho da camisa que você deseja adicionar: ");
    string tamanhoDaCamisa = Console.ReadLine()!;
    Console.WriteLine("Digite o preço da camisa: ");
    double preco;
    while (!double.TryParse(Console.ReadLine(), out preco))
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
    estoquePontoDoClubista.AdicionarCamisa(novaCamisa);
    Console.WriteLine("\nCamisa adicionada com sucesso!");
}

//teste para verificar commit
//teste para enviar para o github
