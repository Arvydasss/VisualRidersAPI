using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIforVisualRiders.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
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
                name: "DeliveryOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BranchId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Measure = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Tax = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
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
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
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
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryOptionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryOption_DeliveryOptionId",
                        column: x => x.DeliveryOptionId,
                        principalTable: "DeliveryOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Customer_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Discount = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategory_Discount_Discount",
                        column: x => x.Discount,
                        principalTable: "Discount",
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
                    table.ForeignKey(
                        name: "FK_Service_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemCategory = table.Column<Guid>(type: "TEXT", nullable: true),
                    Discount = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasableItems_Discount_Discount",
                        column: x => x.Discount,
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasableItems_ItemCategory_ItemCategory",
                        column: x => x.ItemCategory,
                        principalTable: "ItemCategory",
                        principalColumn: "Id");
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
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FulfillmentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tip = table.Column<decimal>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Customer = table.Column<Guid>(type: "TEXT", nullable: false),
                    Employee = table.Column<Guid>(type: "TEXT", nullable: false),
                    Discount = table.Column<Guid>(type: "TEXT", nullable: false),
                    Delivery = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_Customer",
                        column: x => x.Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Delivery_Delivery",
                        column: x => x.Delivery,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Discount_Discount",
                        column: x => x.Discount,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_Employee",
                        column: x => x.Employee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReservationStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "ActiveSince", "BillingDetails", "LegalCompanyName", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "1001-01-01", "lool", "FirstCompany", "FirstCompanyName", 0 },
                    { new Guid("eb40e221-ca09-4e0b-b5d3-fffd59d17467"), "2222-01-01", "lool", "SecondCompany", "SecondCompanyName", 0 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryOption",
                columns: new[] { "Id", "BranchId", "Price", "Title" },
                values: new object[] { new Guid("0a0befb9-9c44-4ee6-a236-447e327aecdf"), new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), 12.34m, "HomeDelivery1" });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Amount", "Code", "EndDate", "Measure", "StartDate" },
                values: new object[,]
                {
                    { new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), 30m, "NUOLAIDA30", new DateTime(2023, 3, 31, 15, 24, 0, 141, DateTimeKind.Local).AddTicks(202), 1, new DateTime(2022, 12, 31, 15, 24, 0, 141, DateTimeKind.Local).AddTicks(201) },
                    { new Guid("d1ddfa55-6c5f-4a40-8457-7ef0e75f8998"), 20m, "NUOLAIDA20", new DateTime(2023, 3, 31, 15, 24, 0, 141, DateTimeKind.Local).AddTicks(198), 1, new DateTime(2022, 12, 31, 15, 24, 0, 141, DateTimeKind.Local).AddTicks(196) }
                });

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
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("64a23a17-c50c-4773-87f5-bb06be1ee5b7"), "Cabbage" });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "Company", "Contacts", "Status", "WorkingDays", "WorkingHourEndStr", "WorkingHourStartStr" },
                values: new object[] { new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "AddrStr", new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "+3706112", 0, 1, "11:11", "00:00" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DiscountId", "Email", "Name", "Password", "PhoneNumber", "RegisterDate", "Status" },
                values: new object[,]
                {
                    { new Guid("297b20c3-cc07-4e21-b82d-2cac485d10b8"), new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "makalyte@gmail.com", "Dalytė", "makalyte123", "+3708145141", new DateTime(2022, 12, 31, 15, 24, 0, 138, DateTimeKind.Local).AddTicks(7720), 1 },
                    { new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "petr@gmail.com", "Petras", "petriok123", "+370812252", new DateTime(2022, 12, 31, 15, 24, 0, 138, DateTimeKind.Local).AddTicks(7764), 1 }
                });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "Id", "Address", "DeliveryOptionId" },
                values: new object[] { new Guid("1fe97290-aa7f-44bf-9106-73fffe024a91"), "Pikadili Str 13", new Guid("0a0befb9-9c44-4ee6-a236-447e327aecdf") });

            migrationBuilder.InsertData(
                table: "ItemCategory",
                columns: new[] { "Id", "Description", "Discount", "Name" },
                values: new object[,]
                {
                    { new Guid("b7f33650-9191-46b2-a721-2282bb85a281"), "somthing222", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "Category222" },
                    { new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), "somthing", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "Category1" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "PermissionId", "Title" },
                values: new object[,]
                {
                    { new Guid("4d43baa3-79ff-40b7-b9cc-85c5f64b0808"), new Guid("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"), "Bartender" },
                    { new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), new Guid("1a2fdbd4-3278-4505-920d-106a1826c6ea"), "Admin" },
                    { new Guid("bfb9d3fd-5ea8-459d-b333-837f759b6a22"), new Guid("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"), "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CompanyId", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[,]
                {
                    { new Guid("2a4ed57e-b2f8-4a34-9178-f2d763de0e8e"), new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "arvydas@gmail.com", "Arvydas", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 0 },
                    { new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "rokas@gmail.com", "Rokas", "rokas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 0 },
                    { new Guid("58797525-74da-4978-a0c7-2f88ed1cc3d0"), new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "danielius@gmail.com", "Danielius", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 0 },
                    { new Guid("bf67a229-cfdd-4838-8d23-f5556e48cf43"), new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), "paulina@gmail.com", "Paulina", "arvydas", new Guid("56959975-10b8-4199-b4b1-5705d82eba91"), 1 }
                });

            migrationBuilder.InsertData(
                table: "PurchasableItems",
                columns: new[] { "Id", "Description", "Discount", "Duration", "ItemCategory", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { new Guid("de52b033-caab-4eba-acad-1819ec024448"), "Desc1", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), 10, new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), "PurchItem1", 5.27m, 1 },
                    { new Guid("e11b0107-a867-4b3d-996f-6ed0ff31d320"), "Desc2", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), 7, new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), "PurchItem222", 5.27m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "BranchId", "Description", "DiscountId", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { new Guid("874a889a-604b-4eb4-90dc-e767e6ff4d8e"), new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "Service1Description", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "ServiceName", 12.34m, 1 },
                    { new Guid("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"), new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), "Service2Description", new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), "ServiceName2", 10.23m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Comment", "Customer", "Delivery", "Discount", "Employee", "FulfillmentDate", "OrderItemId", "Status", "SubmissionDate", "Tip" },
                values: new object[,]
                {
                    { new Guid("c2548b4a-cc25-4155-ab87-8e4cbd8982b4"), "Nothing", new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), new Guid("1fe97290-aa7f-44bf-9106-73fffe024a91"), new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), null, 0, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), 1.24m },
                    { new Guid("dfa0b800-03a7-4894-a20f-ff00660d15e1"), "Abcdefu", new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), new Guid("1fe97290-aa7f-44bf-9106-73fffe024a91"), new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), null, 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), 1.24m },
                    { new Guid("eceba813-ac14-4e03-b5e3-756bae902441"), "Woop", new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), new Guid("1fe97290-aa7f-44bf-9106-73fffe024a91"), new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"), new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), null, 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), 1.24m }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "EmployeeId", "EndTime", "OrderId", "ReservationStatus", "ServiceId", "StartTime" },
                values: new object[] { new Guid("0390744e-e57c-4879-921b-3029fd3d3fc0"), new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), new DateTime(2022, 12, 31, 18, 24, 0, 141, DateTimeKind.Local).AddTicks(163), new Guid("eceba813-ac14-4e03-b5e3-756bae902441"), 0, new Guid("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"), new DateTime(2022, 12, 31, 15, 24, 0, 141, DateTimeKind.Local).AddTicks(149) });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Company",
                table: "Branch",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DiscountId",
                table: "Customer",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryOptionId",
                table: "Delivery",
                column: "DeliveryOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_Discount",
                table: "ItemCategory",
                column: "Discount");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer",
                table: "Order",
                column: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Delivery",
                table: "Order",
                column: "Delivery");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Discount",
                table: "Order",
                column: "Discount");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Employee",
                table: "Order",
                column: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderItemId",
                table: "Order",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasableItems_Discount",
                table: "PurchasableItems",
                column: "Discount");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasableItems_ItemCategory",
                table: "PurchasableItems",
                column: "ItemCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EmployeeId",
                table: "Reservation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_OrderId",
                table: "Reservation",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ServiceId",
                table: "Reservation",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_PermissionId",
                table: "Role",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BranchId",
                table: "Service",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_DiscountId",
                table: "Service",
                column: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PurchasableItems");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "DeliveryOption");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
