using estoqueCamisasDotNet.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoqueCamisasDotNet.Banco;

internal class CamisasDal
{
    public List<Camisas> Listar()
    {
        var lista = new List<Camisas>();
        using var connection = new estoqueDeCamisasDotNetContext().ObterConexao();
        connection.Open();

        string sql = "SELECT *FROM Camisas";
        SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {

            string nomeDoTime = Convert.ToString(dataReader["NomeDoTime"]);
            string tamanhoDaCamisa = Convert.ToString(dataReader["Tamanho"]);
            double precoDaCamisa = Convert.ToDouble(dataReader["Preco"]);
            int id = Convert.ToInt32(dataReader["Id"]);
            Camisas camisa = new(nomeDoTime, tamanhoDaCamisa, precoDaCamisa, id);
            lista.Add(camisa);
        }

        return lista;
    }

    public void Adcionar(Camisas camisa)
    {
        using var connection = new estoqueDeCamisasDotNetContext().ObterConexao();
        connection.Open();

        string sql = "INSERT INTO Camisas (Id, NomeDoTime, Tamanho, Preco) " +
            "VALUES (@Id, @NomeDoTime, @Tamanho, @Preco)";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", camisa.Id);
        command.Parameters.AddWithValue("@NomeDoTime", camisa.NomeDoTime);
        command.Parameters.AddWithValue("@Tamanho", camisa.Tamanho);
        command.Parameters.AddWithValue("@Preco", camisa.Preco);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");

    }

    public void Atualizar(Camisas camisa)
    {
        using var connection = new estoqueDeCamisasDotNetContext().ObterConexao();
        connection.Open();

        string sql = "UPDATE Camisas SET NomeDoTime = @NomeDoTime, " +
            "Tamanho = @Tamanho, Preco = @Preco WHERE Id = @Id";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", camisa.Id);
        command.Parameters.AddWithValue("@NomeDoTime", camisa.NomeDoTime);
        command.Parameters.AddWithValue("@Tamanho", camisa.Tamanho);
        command.Parameters.AddWithValue("@Preco", camisa.Preco);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas atualizadas: {retorno}");

    }

    public void Deletar(Camisas camisa)
    {
        using var connection = new estoqueDeCamisasDotNetContext().ObterConexao();
        connection.Open();

        string sql = "DELET FROM Camisas WHERE Id = @Id";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", camisa.Id);
        command.Parameters.AddWithValue("@NomeDoTime", camisa.NomeDoTime);
        command.Parameters.AddWithValue("@Tamanho", camisa.Tamanho);
        command.Parameters.AddWithValue("@Preco", camisa.Preco);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas deletadas: {retorno}");
    }
}
