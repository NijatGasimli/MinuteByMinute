using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateTurkishCargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.AlterColumn<int>(
                name: "DeclaredCargosId",
                table: "TurkishStorages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.AlterColumn<int>(
                name: "DeclaredCargosId",
                table: "TurkishStorages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages",
                column: "DeclaredCargosId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages",
                column: "DeclaredCargosId",
                principalTable: "DeclaredCargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
