using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropColumn(
                name: "DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.AddColumn<int>(
                name: "TurkishStorageId",
                table: "DeclaredCargos",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DeclaredCargosId",
                table: "TurkishStorages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages",
                column: "DeclaredCargosId",
                unique: true,
                filter: "[DeclaredCargosId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages",
                column: "DeclaredCargosId",
                principalTable: "DeclaredCargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
