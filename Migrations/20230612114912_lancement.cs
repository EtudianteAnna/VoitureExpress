using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class lancement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Voitures_VoitureId",
                table: "Reparation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "Voiture");

            migrationBuilder.RenameTable(
                name: "Reparation",
                newName: "ReparationVoiture");

            migrationBuilder.RenameIndex(
                name: "IX_Reparation_VoitureId",
                table: "ReparationVoiture",
                newName: "IX_ReparationVoiture_VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReparationVoiture",
                table: "ReparationVoiture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId",
                table: "ReparationVoiture",
                column: "VoitureId",
                principalTable: "Voiture",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoiture_Voiture_VoitureId",
                table: "ReparationVoiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReparationVoiture",
                table: "ReparationVoiture");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "Voitures");

            migrationBuilder.RenameTable(
                name: "ReparationVoiture",
                newName: "Reparation");

            migrationBuilder.RenameIndex(
                name: "IX_ReparationVoiture_VoitureId",
                table: "Reparation",
                newName: "IX_Reparation_VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Voitures_VoitureId",
                table: "Reparation",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "VoitureId");
        }
    }
}
