﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Northwind.Data;

#nullable disable

namespace APIforVisualRiders.Migrations
{
    [DbContext(typeof(VisualRidersContext))]
    [Migration("20221231123254_work")]
    partial class work
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("APIforVisualRiders.Models.ItemCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Discount");

                    b.ToTable("ItemCategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"),
                            Description = "somthing",
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Name = "Category1"
                        },
                        new
                        {
                            Id = new Guid("cf7ca688-2da8-4ce0-b06c-6fed6095fb48"),
                            Description = "somthing222",
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Name = "Category222"
                        });
                });

            modelBuilder.Entity("APIforVisualRiders.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Customer")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Delivery")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Employee")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FulfillmentDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderItemId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Tip")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Customer");

                    b.HasIndex("Discount");

                    b.HasIndex("Employee");

                    b.HasIndex("OrderItemId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = new Guid("439b4c3f-fc3b-4cf0-93d1-30d974f68d2a"),
                            Comment = "Nothing",
                            Customer = new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"),
                            Delivery = new Guid("00000000-0000-0000-0000-000000000000"),
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Employee = new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"),
                            FulfillmentDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            SubmissionDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Tip = 1.24m
                        },
                        new
                        {
                            Id = new Guid("e7dc93e9-da0d-4045-8f5e-b0a69e5ade5f"),
                            Comment = "Abcdefu",
                            Customer = new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"),
                            Delivery = new Guid("00000000-0000-0000-0000-000000000000"),
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Employee = new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"),
                            FulfillmentDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 1,
                            SubmissionDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Tip = 1.24m
                        },
                        new
                        {
                            Id = new Guid("eceba813-ac14-4e03-b5e3-756bae902441"),
                            Comment = "Woop",
                            Customer = new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"),
                            Delivery = new Guid("00000000-0000-0000-0000-000000000000"),
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Employee = new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"),
                            FulfillmentDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 1,
                            SubmissionDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Tip = 1.24m
                        });
                });

            modelBuilder.Entity("APIforVisualRiders.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Tax")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("APIforVisualRiders.Models.PurchasableItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ItemCategory")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Discount");

                    b.HasIndex("ItemCategory");

                    b.ToTable("PurchasableItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d8f49bb-b216-452b-af4f-f8cc690b0318"),
                            Description = "Desc1",
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Duration = 10,
                            ItemCategory = new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"),
                            Name = "PurchItem1",
                            Price = 5.27m,
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("44be6764-7418-4d19-8058-f5f35358081f"),
                            Description = "Desc2",
                            Discount = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Duration = 7,
                            ItemCategory = new Guid("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"),
                            Name = "PurchItem222",
                            Price = 5.27m,
                            Status = 0
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Company")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkingDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkingHourEndStr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkingHourStartStr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.ToTable("Branch");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"),
                            Address = "AddrStr",
                            Company = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            Contacts = "+3706112",
                            Status = 0,
                            WorkingDays = 1,
                            WorkingHourEndStr = "11:11",
                            WorkingHourStartStr = "00:00"
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ActiveSince")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BillingDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalCompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            ActiveSince = "1001-01-01",
                            BillingDetails = "lool",
                            LegalCompanyName = "FirstCompany",
                            Name = "FirstCompanyName",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("c9bb3ad5-92bf-4a72-8223-432f2470bac1"),
                            ActiveSince = "2222-01-01",
                            BillingDetails = "lool",
                            LegalCompanyName = "SecondCompany",
                            Name = "SecondCompanyName",
                            Status = 0
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c91e1f82-1577-474c-9396-c0af97156c28"),
                            DiscountId = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Email = "makalyte@gmail.com",
                            Name = "Dalytė",
                            Password = "makalyte123",
                            PhoneNumber = "+3708145141",
                            RegisterDate = new DateTime(2022, 12, 31, 14, 32, 53, 834, DateTimeKind.Local).AddTicks(5745),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("7e3de3f7-826f-49e0-bad4-e996d92a0d88"),
                            DiscountId = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Email = "petr@gmail.com",
                            Name = "Petras",
                            Password = "petriok123",
                            PhoneNumber = "+370812252",
                            RegisterDate = new DateTime(2022, 12, 31, 14, 32, 53, 834, DateTimeKind.Local).AddTicks(5787),
                            Status = 1
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Measure")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f058258-104b-46d1-a67c-07b7ff84d780"),
                            Amount = 20m,
                            Code = "NUOLAIDA20",
                            EndDate = new DateTime(2023, 3, 31, 14, 32, 53, 836, DateTimeKind.Local).AddTicks(5052),
                            Measure = 1,
                            StartDate = new DateTime(2022, 12, 31, 14, 32, 53, 836, DateTimeKind.Local).AddTicks(5051)
                        },
                        new
                        {
                            Id = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Amount = 30m,
                            Code = "NUOLAIDA30",
                            EndDate = new DateTime(2023, 3, 31, 14, 32, 53, 836, DateTimeKind.Local).AddTicks(5057),
                            Measure = 1,
                            StartDate = new DateTime(2022, 12, 31, 14, 32, 53, 836, DateTimeKind.Local).AddTicks(5056)
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8088044d-25a3-4614-9557-6a39bc267622"),
                            CompanyId = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            Email = "arvydas@gmail.com",
                            Name = "Arvydas",
                            Password = "arvydas",
                            RoleId = new Guid("56959975-10b8-4199-b4b1-5705d82eba91"),
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("8d60791c-1f90-46ae-bea1-a2c4474c23ef"),
                            CompanyId = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            Email = "danielius@gmail.com",
                            Name = "Danielius",
                            Password = "arvydas",
                            RoleId = new Guid("56959975-10b8-4199-b4b1-5705d82eba91"),
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("d1769174-677f-4c5b-833a-6e59fa43c4ae"),
                            CompanyId = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            Email = "paulina@gmail.com",
                            Name = "Paulina",
                            Password = "arvydas",
                            RoleId = new Guid("56959975-10b8-4199-b4b1-5705d82eba91"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"),
                            CompanyId = new Guid("d1ce4e4b-813f-4c89-9440-19cfb83a7669"),
                            Email = "rokas@gmail.com",
                            Name = "Rokas",
                            Password = "rokas",
                            RoleId = new Guid("56959975-10b8-4199-b4b1-5705d82eba91"),
                            Status = 0
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a2fdbd4-3278-4505-920d-106a1826c6ea"),
                            Title = "Secure system"
                        },
                        new
                        {
                            Id = new Guid("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"),
                            Title = "Check employees health insurance"
                        },
                        new
                        {
                            Id = new Guid("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"),
                            Title = "Check products"
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd110338-b20a-486a-85e3-75fa4367541f"),
                            Name = "Cabbage"
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("efc175c0-854d-4c85-9b12-24e10eb655a8"),
                            EmployeeId = new Guid("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"),
                            EndTime = new DateTime(2022, 12, 31, 17, 32, 53, 836, DateTimeKind.Local).AddTicks(5025),
                            OrderId = new Guid("eceba813-ac14-4e03-b5e3-756bae902441"),
                            ReservationStatus = 0,
                            ServiceId = new Guid("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"),
                            StartTime = new DateTime(2022, 12, 31, 14, 32, 53, 836, DateTimeKind.Local).AddTicks(5016)
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56959975-10b8-4199-b4b1-5705d82eba91"),
                            PermissionId = new Guid("1a2fdbd4-3278-4505-920d-106a1826c6ea"),
                            Title = "Admin"
                        },
                        new
                        {
                            Id = new Guid("0acd9050-8933-4115-814b-1b79f55582d4"),
                            PermissionId = new Guid("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"),
                            Title = "Manager"
                        },
                        new
                        {
                            Id = new Guid("b223c3ed-370a-4eab-b809-b2307d0e8d97"),
                            PermissionId = new Guid("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"),
                            Title = "Bartender"
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Service");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0df7631c-91f1-460d-a271-23c1ed05fe39"),
                            BranchId = new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"),
                            Description = "Service1Description",
                            DiscountId = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Name = "ServiceName",
                            Price = 12.34m,
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"),
                            BranchId = new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"),
                            Description = "Service2Description",
                            DiscountId = new Guid("70163c24-2c08-4924-a2a2-abb4e2079a0b"),
                            Name = "ServiceName2",
                            Price = 10.23m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("APIforVisualRiders.Models.ItemCategory", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("Discount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIforVisualRiders.Models.Order", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiForVisualRiders.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("Discount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiForVisualRiders.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIforVisualRiders.Models.OrderItem", "OrderItem")
                        .WithMany()
                        .HasForeignKey("OrderItemId");

                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("APIforVisualRiders.Models.PurchasableItem", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("Discount");

                    b.HasOne("APIforVisualRiders.Models.ItemCategory", null)
                        .WithMany()
                        .HasForeignKey("ItemCategory");
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Branch", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Customer", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Employee", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiForVisualRiders.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Reservation", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIforVisualRiders.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiForVisualRiders.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Role", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Service", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Branch", null)
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiForVisualRiders.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}