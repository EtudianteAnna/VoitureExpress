using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class voiture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropColumn(
                name: "CoûtsDeRéparations",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Disponibilité",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Réparations",
                table: "Voitures");

            migrationBuilder.AlterColumn<string>(
                name: "Modele",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marque",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Finition",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeVente",
                table: "Voitures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disponibilite",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reparation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoutReparation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reparation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparation_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "VoitureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_VoitureId",
                table: "Reparation",
                column: "VoitureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparation");

            migrationBuilder.DropColumn(
                name: "Disponibilite",
                table: "Voitures");

            migrationBuilder.AlterColumn<string>(
                name: "Modele",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Marque",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Finition",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeVente",
                table: "Voitures",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "CoûtsDeRéparations",
                table: "Voitures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Disponibilité",
                table: "Voitures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Voitures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Réparations",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoitureId = table.Column<int>(type: "int", nullable: false),
                    Cout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateIntervention = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interventions_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "VoitureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_VoitureId",
                table: "Interventions",
                column: "VoitureId");
        }
    }
}
