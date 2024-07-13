using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoqueCamisasDotNet.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Camisas", new string[] 
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] {"Sevilla", "G", 199.00m});
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Barcelona", "M", 249.99m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Real Madrid", "P", 279.50m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Manchester United", "G", 220.00m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Liverpool", "M", 230.75m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Bayern Munich", "P", 215.00m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Juventus", "G", 225.50m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Paris Saint-Germain", "M", 235.99m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "Chelsea", "P", 210.00m });
            migrationBuilder.InsertData("Camisas", new string[]
            { "NomeDoTime", "Tamanho", "Preco" }, new object[] { "AC Milan", "G", 240.50m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas");
        }
    }
}
