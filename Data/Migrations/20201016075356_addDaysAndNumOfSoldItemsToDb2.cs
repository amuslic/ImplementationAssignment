using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImplementationAssignment.Migrations
{
    public partial class addDaysAndNumOfSoldItemsToDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "daysInAWeek",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daysInAWeek", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "numOfSoldItemsPerDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    NumOfItemsSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numOfSoldItemsPerDay", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "daysInAWeek");

            migrationBuilder.DropTable(
                name: "numOfSoldItemsPerDay");
        }
    }
}
