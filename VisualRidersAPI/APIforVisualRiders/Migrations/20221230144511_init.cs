using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIforVisualRiders.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    WorkingHourStartStr = table.Column<string>(type: "TEXT", nullable: false),
                    WorkingHourEndStr = table.Column<string>(type: "TEXT", nullable: false),
                    WorkingDays = table.Column<int>(type: "INTEGER", nullable: false),
                    Contacts = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Company = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

           

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "Company", "Contacts", "Status", "WorkingDays", "WorkingHourEndStr", "WorkingHourStartStr" },
                values: new object[] { new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "AddrStr", new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "+3706112", 0, 1, "11:11", "00:00" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritory_EmployeeId",
                table: "EmployeeTerritory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritory_TerritoryId",
                table: "EmployeeTerritory",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "EmployeeTerritory");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
