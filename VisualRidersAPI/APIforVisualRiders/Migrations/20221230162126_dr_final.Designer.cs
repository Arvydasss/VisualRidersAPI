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
    [DbContext(typeof(NorthwindContext))]
    [Migration("20221230162126_dr_final")]
    partial class drfinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

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
                            Id = new Guid("a5137d4f-6d79-4d44-a2f3-14b510e898e5"),
                            ActiveSince = "2222-01-01",
                            BillingDetails = "lool",
                            LegalCompanyName = "SecondCompany",
                            Name = "SecondCompanyName",
                            Status = 0
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

                    b.ToTable("Service");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae373986-9f2d-4fbe-9e97-d47fd8fcdf54"),
                            BranchId = new Guid("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"),
                            Description = "Service1Description",
                            DiscountId = new Guid("7b341d74-68fa-408c-9816-5f5d7fe9a74d"),
                            Name = "ServiceName",
                            Price = 12.34m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("apiForVisualRiders.Models.Branch", b =>
                {
                    b.HasOne("apiForVisualRiders.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("Company")
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
                });
#pragma warning restore 612, 618
        }
    }
}
