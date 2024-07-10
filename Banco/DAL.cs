using estoqueCamisasDotNet.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoqueCamisasDotNet.Banco;


internal class DAL<T> where T : class
{
    protected readonly estoqueDeCamisasDotNetContext context;

    public DAL(estoqueDeCamisasDotNetContext context)
    {
        this.context = context;
    }

    public  IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    
    public void Adcionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }

    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

}
