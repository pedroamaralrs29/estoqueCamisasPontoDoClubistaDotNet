using estoqueCamisasDotNet.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace estoqueCamisasDotNet.Banco
{
    internal class estoqueDeCamisasDotNetContext : DbContext
    {
        public DbSet<Camisas> Camisas { get; set; } 

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PontoDoClubistaV0;Integrated Security=True;" +
            "Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
