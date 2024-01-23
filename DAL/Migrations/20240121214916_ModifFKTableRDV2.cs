using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ModifFKTableRDV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patient",
                table: "RDV");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "RDV",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RDV_PatientId",
                table: "RDV",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RDV_T_Patient_PatientId",
                table: "RDV",
                column: "PatientId",
                principalTable: "T_Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RDV_T_Patient_PatientId",
                table: "RDV");

            migrationBuilder.DropIndex(
                name: "IX_RDV_PatientId",
                table: "RDV");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "RDV");

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "RDV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
