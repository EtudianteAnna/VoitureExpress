using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class jointure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoitureId1",
                table: "ReparationVoiture",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReparationVoiture_VoitureId1",
                table: "ReparationVoiture",
                column: "VoitureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId1",
                table: "ReparationVoiture",
                column: "VoitureId1",
                principalTable: "Voiture",
                principalColumn: "VoitureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId1",
                table: "ReparationVoiture");

            migrationBuilder.DropIndex(
                name: "IX_ReparationVoiture_VoitureId1",
                table: "ReparationVoiture");

            migrationBuilder.DropColumn(
                name: "VoitureId1",
                table: "ReparationVoiture");
        }
    }
}
