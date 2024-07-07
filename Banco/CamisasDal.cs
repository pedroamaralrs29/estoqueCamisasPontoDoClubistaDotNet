using estoqueCamisasDotNet.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoqueCamisasDotNet.Banco;

internal class CamisasDal
{
    private readonly estoqueDeCamisasDotNetContext context;

    public CamisasDal(estoqueDeCamisasDotNetContext context)
    {
        this.context = context;
    }

    public List<Camisas> Listar()
    {

        return context.Camisas.ToList();
    }

    public void Adcionar(Camisas camisa)
    {
        context.Camisas.Add(camisa);
        context.SaveChanges();
    }

    public void Atualizar(Camisas camisa)
    {
        context.Camisas.Update(camisa);
        context.SaveChanges();
    }

    public void Deletar(Camisas camisa)
    {
        context.Camisas.Remove(camisa);
        context.SaveChanges();
    }

    public Camisas? procurarPeloNomeDoTime(string nomeDoTime)
    {
        return context.Camisas.FirstOrDefault(c => c.NomeDoTime.Equals(nomeDoTime, StringComparison.OrdinalIgnoreCase));
    }
}
