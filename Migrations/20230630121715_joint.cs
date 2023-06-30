using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class joint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId",
                table: "ReparationVoiture");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId1",
                table: "ReparationVoiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "Voitures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "VoitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voitures_VoitureId",
                table: "ReparationVoiture",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voitures_VoitureId1",
                table: "ReparationVoiture",
                column: "VoitureId1",
                principalTable: "Voitures",
                principalColumn: "VoitureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voitures_VoitureId",
                table: "ReparationVoiture");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voitures_VoitureId1",
                table: "ReparationVoiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "Voiture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "VoitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId",
                table: "ReparationVoiture",
                column: "VoitureId",
                principalTable: "Voiture",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId1",
                table: "ReparationVoiture",
                column: "VoitureId1",
                principalTable: "Voiture",
                principalColumn: "VoitureId");
        }
    }
}
