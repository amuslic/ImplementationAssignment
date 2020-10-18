using Microsoft.EntityFrameworkCore.Migrations;

namespace ImplementationAssignment.Migrations
{
    public partial class addDaysAndNumOfSoldItemsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "saleDatas",
                newName: "SaleDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleDataId",
                table: "saleDatas",
                newName: "Id");
        }
    }
}
