using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeclaredCargosId",
                table: "TurkishStorages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeclaredCargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclaredCargos", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurkishStorages_DeclaredCargos_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropTable(
                name: "DeclaredCargos");

            migrationBuilder.DropIndex(
                name: "IX_TurkishStorages_DeclaredCargosId",
                table: "TurkishStorages");

            migrationBuilder.DropColumn(
                name: "DeclaredCargosId",
                table: "TurkishStorages");
        }
    }
}
