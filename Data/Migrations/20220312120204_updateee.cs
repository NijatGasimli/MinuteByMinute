using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclaredCargos_TurkishStorages_TurkishStorageId",
                table: "DeclaredCargos");

            migrationBuilder.DropIndex(
                name: "IX_DeclaredCargos_TurkishStorageId",
                table: "DeclaredCargos");

            migrationBuilder.DropColumn(
                name: "TurkishStorageId",
                table: "DeclaredCargos");

            migrationBuilder.AddColumn<int>(
                name: "CargosId",
                table: "DeclaredCargos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclaredCargos_CargosId",
                table: "DeclaredCargos",
                column: "CargosId",
                unique: true,
                filter: "[CargosId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclaredCargos_Cargos_CargosId",
                table: "DeclaredCargos",
                column: "CargosId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclaredCargos_Cargos_CargosId",
                table: "DeclaredCargos");

            migrationBuilder.DropIndex(
                name: "IX_DeclaredCargos_CargosId",
                table: "DeclaredCargos");

            migrationBuilder.DropColumn(
                name: "CargosId",
                table: "DeclaredCargos");

            migrationBuilder.AddColumn<int>(
                name: "TurkishStorageId",
                table: "DeclaredCargos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclaredCargos_TurkishStorageId",
                table: "DeclaredCargos",
                column: "TurkishStorageId",
                unique: true,
                filter: "[TurkishStorageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclaredCargos_TurkishStorages_TurkishStorageId",
                table: "DeclaredCargos",
                column: "TurkishStorageId",
                principalTable: "TurkishStorages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
