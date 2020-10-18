using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImplementationAssignment.Migrations
{
    public partial class addSaleDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "saleDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SalesPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saleDatas");
        }
    }
}
