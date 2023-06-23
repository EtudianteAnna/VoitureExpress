using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class reparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeIntervention",
                table: "ReparationVoiture",
                newName: "TypeReparation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeReparation",
                table: "ReparationVoiture",
                newName: "TypeIntervention");
        }
    }
}
