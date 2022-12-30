using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIforVisualRiders.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
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
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
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

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "ActiveSince", "BillingDetails", "LegalCompanyName", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("cdc4ddcd-2297-4f94-bc59-232eaa163d0f"), "2222-01-01", "lool", "SecondCompany", "SecondCompanyName", 0 },
                    { new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "1001-01-01", "lool", "FirstCompany", "FirstCompanyName", 0 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DiscountId", "Email", "Name", "Password", "PhoneNumber", "RegisterDate", "Status" },
                values: new object[] { new Guid("f176747e-1e72-4cc7-b1a2-bea508c6fd4a"), new Guid("5c16ec31-6d8d-4d34-8332-05beb8b4ae37"), "makalyte@gmail.com", "Dalytė", "makalyte123", "+3708145141", new DateTime(2022, 12, 30, 19, 43, 25, 512, DateTimeKind.Local).AddTicks(9071), 1 });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1a2fdbd4-3278-4505-920d-106a1826c6ea"), "Secure system" },
                    { new Guid("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"), "Check employees health insurance" },
                    { new Guid("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"), "Check products" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "Company", "Contacts", "Status", "WorkingDays", "WorkingHourEndStr", "WorkingHourStartStr" },
                values: new object[] { new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "AddrStr", new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "+3706112", 0, 1, "11:11", "00:00" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "PermissionId", "Title" },
                values: new object[,]
                {
                    { new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), new Guid("1a2fdbd4-3278-4505-920d-106a1826c6ea"), "Admin" },
                    { new Guid("b9eac8ed-a3fc-4c57-a435-9e6936d96de6"), new Guid("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"), "Bartender" },
                    { new Guid("c8f9db05-6223-454e-b4e6-bbeb9b6e1918"), new Guid("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"), "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CompanyId", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[,]
                {
                    { new Guid("39424208-f5e1-4798-b0c8-b6035fe4df48"), new Guid("00000000-0000-0000-0000-000000000000"), "arvydas@gmail.com", "Arvydas", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 0 },
                    { new Guid("86ebf306-3969-4fda-afbf-977c2957cb33"), new Guid("00000000-0000-0000-0000-000000000000"), "danielius@gmail.com", "Danielius", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 0 },
                    { new Guid("be18c669-83c6-4b5d-b40a-06380a2de3cc"), new Guid("00000000-0000-0000-0000-000000000000"), "paulina@gmail.com", "Paulina", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "BranchId", "Description", "DiscountId", "Name", "Price", "Status" },
                values: new object[] { new Guid("44f00df9-07e9-4717-99ae-5fea998dbc04"), new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "Service1Description", new Guid("f1ece8d7-28ce-44c4-b8c4-d112a4a3b741"), "ServiceName", 12.34m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Company",
                table: "Branch",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_PermissionId",
                table: "Role",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BranchId",
                table: "Service",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
