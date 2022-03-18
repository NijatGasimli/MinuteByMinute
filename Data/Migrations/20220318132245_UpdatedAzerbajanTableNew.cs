using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdatedAzerbajanTableNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achieve",
                table: "AzerbaijanStorages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Isdeleted",
                table: "AzerbaijanStorages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achieve",
                table: "AzerbaijanStorages");

            migrationBuilder.DropColumn(
                name: "Isdeleted",
                table: "AzerbaijanStorages");
        }
    }
}
