using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvoice",
                table: "TurkishStorages");

            migrationBuilder.AddColumn<bool>(
                name: "IsInvoice",
                table: "Cargos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvoice",
                table: "Cargos");

            migrationBuilder.AddColumn<bool>(
                name: "IsInvoice",
                table: "TurkishStorages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
