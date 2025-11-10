using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompenseAgora.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEnergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEnergy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEnergyGas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TypeEnergyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEnergyGas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeEnergyGas_TypeEnergy_TypeEnergyID",
                        column: x => x.TypeEnergyID,
                        principalTable: "TypeEnergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationEnergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnityID = table.Column<int>(type: "int", nullable: false),
                    AnnualReference = table.Column<bool>(type: "bit", nullable: false),
                    WhenRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmissionCO2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationEnergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizationEnergy_Unity_UnityID",
                        column: x => x.UnityID,
                        principalTable: "Unity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolarEnergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnityID = table.Column<int>(type: "int", nullable: false),
                    MonthYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Font = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionFont = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnnualReference = table.Column<bool>(type: "bit", nullable: false),
                    QuantityGenerated = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityConsumed = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissaoCO2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissionCO2Biogenic = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissionCO2BiogenicRemoved = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarEnergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarEnergy_Unity_UnityID",
                        column: x => x.UnityID,
                        principalTable: "Unity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEnergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnityID = table.Column<int>(type: "int", nullable: false),
                    YearMonth = table.Column<DateOnly>(type: "date", nullable: false),
                    Font = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FontDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhenRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnualReference = table.Column<bool>(type: "bit", nullable: false),
                    EnergyTypeCode = table.Column<int>(type: "int", nullable: false),
                    TypeEnergyGasID = table.Column<int>(type: "int", nullable: true),
                    HasEmissionFactor = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    EficiencyPlantGenerator = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissionCO2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissionCO2Biogenic = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QuantityEmissaoCO2BiogenicRemoved = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEnergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseEnergy_TypeEnergyGas_TypeEnergyGasID",
                        column: x => x.TypeEnergyGasID,
                        principalTable: "TypeEnergyGas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseEnergy_TypeEnergy_EnergyTypeCode",
                        column: x => x.EnergyTypeCode,
                        principalTable: "TypeEnergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseEnergy_Unity_UnityID",
                        column: x => x.UnityID,
                        principalTable: "Unity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationEnergy_UnityID",
                table: "LocalizationEnergy",
                column: "UnityID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEnergy_EnergyTypeCode",
                table: "PurchaseEnergy",
                column: "EnergyTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEnergy_TypeEnergyGasID",
                table: "PurchaseEnergy",
                column: "TypeEnergyGasID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEnergy_UnityID",
                table: "PurchaseEnergy",
                column: "UnityID");

            migrationBuilder.CreateIndex(
                name: "IX_SolarEnergy_UnityID",
                table: "SolarEnergy",
                column: "UnityID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEnergyGas_TypeEnergyID",
                table: "TypeEnergyGas",
                column: "TypeEnergyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizationEnergy");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "PurchaseEnergy");

            migrationBuilder.DropTable(
                name: "SolarEnergy");

            migrationBuilder.DropTable(
                name: "TypeEnergyGas");

            migrationBuilder.DropTable(
                name: "Unity");

            migrationBuilder.DropTable(
                name: "TypeEnergy");
        }
    }
}
