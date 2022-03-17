using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addnewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HaziAslanovOffices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ComingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaziAslanovOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcharisaharOffices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ComingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcharisaharOffices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HaziAslanovOffices");

            migrationBuilder.DropTable(
                name: "IcharisaharOffices");
        }
    }
}
