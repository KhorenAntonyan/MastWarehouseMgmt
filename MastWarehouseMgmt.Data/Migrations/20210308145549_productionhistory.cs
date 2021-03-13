using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MastWarehouseMgmt.Data.Migrations
{
    public partial class productionhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionHistories",
                columns: table => new
                {
                    ProductionHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Cement = table.Column<double>(type: "float", nullable: false),
                    CR400 = table.Column<double>(type: "float", nullable: false),
                    Sand = table.Column<double>(type: "float", nullable: false),
                    Gypsum = table.Column<double>(type: "float", nullable: false),
                    Lithium = table.Column<double>(type: "float", nullable: false),
                    Acronal = table.Column<double>(type: "float", nullable: false),
                    Soda = table.Column<double>(type: "float", nullable: false),
                    Glue = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionHistories", x => x.ProductionHistoryId);
                    table.ForeignKey(
                        name: "FK_ProductionHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionHistories_ProductId",
                table: "ProductionHistories",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionHistories");
        }
    }
}
