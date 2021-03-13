using Microsoft.EntityFrameworkCore.Migrations;

namespace MastWarehouseMgmt.Data.Migrations
{
    public partial class productionhistoryQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductionHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductionHistories");
        }
    }
}
