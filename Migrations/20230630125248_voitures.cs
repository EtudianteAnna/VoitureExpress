using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoitureExpress.Migrations
{
    public partial class voitures : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Reparation_VoitureId1",
                table: "Reparation");

            migrationBuilder.DropColumn(
                name: "VoitureId1",
                table: "Reparation");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "Voitures");

            migrationBuilder.RenameTable(
                name: "Reparation",
                newName: "Reparations");

            migrationBuilder.RenameIndex(
                name: "IX_Reparation_VoitureId",
                table: "Reparations",
                newName: "IX_Reparations_VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparations",
                table: "Reparations",
                column: "ReparationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "VoitureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reparations",
                table: "Reparations");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "Voiture");

            migrationBuilder.RenameTable(
                name: "Reparations",
                newName: "Reparation");

            migrationBuilder.RenameIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparation",
                newName: "IX_Reparation_VoitureId");

            migrationBuilder.AddColumn<int>(
                name: "VoitureId1",
                table: "Reparation",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "VoitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation",
                column: "ReparationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_VoitureId1",
                table: "Reparation",
                column: "VoitureId1");

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
