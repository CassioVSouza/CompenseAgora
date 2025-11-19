using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompenseAgora.Migrations
{
    /// <inheritdoc />
    public partial class Eletricity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactorEletricity",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<short>(type: "smallint", nullable: false),
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    feSIN = table.Column<decimal>(type: "Decimal(18,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorEletricity", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorEletricity");
        }
    }
}
