using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurkishStorages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ComingTime = table.Column<DateTime>(nullable: false),
                    IsInvoice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurkishStorages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurkishStorages");
        }
    }
}
