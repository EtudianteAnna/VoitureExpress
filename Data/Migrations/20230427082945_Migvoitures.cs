using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Data.Migrations
{
    public partial class Migvoiture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voiture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Réparations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoûtsDeRéparations = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponibilité = table.Column<bool>(type: "bit", nullable: false),
                    PrixDeVente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateDeVente = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voiture", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voiture");
        }
    }
}
