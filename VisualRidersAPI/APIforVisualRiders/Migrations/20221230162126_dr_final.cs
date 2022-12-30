using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIforVisualRiders.Migrations
{
    /// <inheritdoc />
    public partial class drfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ActiveSince = table.Column<string>(type: "TEXT", nullable: false),
                    LegalCompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    BillingDetails = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_Branch_Company_Company",
                        column: x => x.Company,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BranchId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "ActiveSince", "BillingDetails", "LegalCompanyName", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("a5137d4f-6d79-4d44-a2f3-14b510e898e5"), "2222-01-01", "lool", "SecondCompany", "SecondCompanyName", 0 },
                    { new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "1001-01-01", "lool", "FirstCompany", "FirstCompanyName", 0 }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "Company", "Contacts", "Status", "WorkingDays", "WorkingHourEndStr", "WorkingHourStartStr" },
                values: new object[] { new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "AddrStr", new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "+3706112", 0, 1, "11:11", "00:00" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "BranchId", "Description", "DiscountId", "Name", "Price", "Status" },
                values: new object[] { new Guid("ae373986-9f2d-4fbe-9e97-d47fd8fcdf54"), new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "Service1Description", new Guid("7b341d74-68fa-408c-9816-5f5d7fe9a74d"), "ServiceName", 12.34m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Company",
                table: "Branch",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BranchId",
                table: "Service",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
