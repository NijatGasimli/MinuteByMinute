using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Creatdbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "DeclaredCargos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "AzerbaijanStorages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "DeclaredCargos");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "AzerbaijanStorages");
        }
    }
}
