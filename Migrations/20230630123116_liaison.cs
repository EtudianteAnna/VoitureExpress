using Microsoft.EntityFrameworkCore.Migrations;

namespace VoitureExpress.Migrations
{
    public partial class liaison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Voiture_VoitureId",
                table: "Reparation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Voiture_VoitureId1",
                table: "Reparation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "Voitures");

            migrationBuilder.RenameTable(
                name: "Reparation",
                newName: "ReparationVoitures");

            migrationBuilder.RenameIndex(
                name: "IX_Reparation_VoitureId1",
                table: "ReparationVoitures",
                newName: "IX_ReparationVoitures_VoitureId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reparation_VoitureId",
                table: "ReparationVoitures",
                newName: "IX_ReparationVoitures_VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReparationVoitures",
                table: "ReparationVoitures",
                column: "ReparationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoitures_Voitures_VoitureId",
                table: "ReparationVoitures",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparationVoitures_Voitures_VoitureId1",
                table: "ReparationVoitures",
                column: "VoitureId1",
                principalTable: "Voitures",
                principalColumn: "VoitureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoitures_Voitures_VoitureId",
                table: "ReparationVoitures");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparationVoitures_Voitures_VoitureId1",
                table: "ReparationVoitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReparationVoitures",
                table: "ReparationVoitures");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "Voiture");

            migrationBuilder.RenameTable(
                name: "ReparationVoitures",
                newName: "Reparation");

            migrationBuilder.RenameIndex(
                name: "IX_ReparationVoitures_VoitureId1",
                table: "Reparation",
                newName: "IX_Reparation_VoitureId1");

            migrationBuilder.RenameIndex(
                name: "IX_ReparationVoitures_VoitureId",
                table: "Reparation",
                newName: "IX_Reparation_VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation",
                column: "ReparationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Voiture_VoitureId",
                table: "Reparation",
                column: "VoitureId",
                principalTable: "Voiture",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Voiture_VoitureId1",
                table: "Reparation",
                column: "VoitureId1",
                principalTable: "Voiture",
                principalColumn: "VoitureId");
        }
    }
}
