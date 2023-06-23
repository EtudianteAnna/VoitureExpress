using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class affichage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReparationVoiture",
                newName: "ReparationId");

            migrationBuilder.RenameColumn(
                name: "Reparation",
                table: "ReparationVoiture",
                newName: "Reparations");

            migrationBuilder.AddColumn<string>(
                name: "Reparations",
                table: "Voiture",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reparations",
                table: "Voiture");

            migrationBuilder.RenameColumn(
                name: "ReparationId",
                table: "ReparationVoiture",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Reparations",
                table: "ReparationVoiture",
                newName: "Reparation");
        }
    }
}
