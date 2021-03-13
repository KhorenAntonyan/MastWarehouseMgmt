using Microsoft.EntityFrameworkCore.Migrations;

namespace MastWarehouseMgmt.Data.Migrations
{
    public partial class C3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "C3",
                table: "ProductionHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C3",
                table: "ProductionHistories");
        }
    }
}
