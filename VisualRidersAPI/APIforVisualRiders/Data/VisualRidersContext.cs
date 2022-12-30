using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apiForVisualRiders.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using APIforVisualRiders.Models;

namespace Northwind.Data;

public partial class VisualRidersContext : DbContext
{
    public VisualRidersContext(DbContextOptions<VisualRidersContext> options)
        : base(options)
    {
    }

    //---------------------------------------------------------------
    public DbSet<Branch> Branch { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<ItemCategory> ItemCategory { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<PurchasableItem> PurchasableItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        
        //BRANCH
        modelBuilder.Entity<Branch>().HasOne<Company>().WithMany().HasForeignKey(p => p.Company);
        modelBuilder.Entity<Branch>().HasData(
            new Branch { Id = Guid.Parse("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6"), Address = "AddrStr", WorkingHourStartStr = "00:00", WorkingHourEndStr = "11:11", WorkingDays = WorkingDays.Monday, Contacts = "+3706112", Status = BranchStatus.Active, Company = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669") }
          );

        //COMPANY
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669"), Name = "FirstCompanyName", ActiveSince = "1001-01-01", LegalCompanyName = "FirstCompany", BillingDetails = "lool", Status = CompanyStatus.Active },
            new Company { Id = Guid.NewGuid(), Name = "SecondCompanyName", ActiveSince = "2222-01-01", LegalCompanyName = "SecondCompany", BillingDetails = "lool", Status = CompanyStatus.Active }
          );

        //SERVICE
        modelBuilder.Entity<Service>().HasKey(c => c.Id);
        //modelBuilder.Entity<Service>().HasOne<Company>().WithMany().HasForeignKey(p => p.DiscountId); UNCOMMENT KAI BUS DISCOUNT DBSET
        modelBuilder.Entity<Service>().HasOne<Branch>().WithMany().HasForeignKey(p => p.BranchId);
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = Guid.NewGuid(), Name = "ServiceName", Description = "Service1Description", Price = 12.34m, Status = ServiceStatus.Active, DiscountId = Guid.NewGuid(), BranchId = Guid.Parse("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6") }
          );

        //PERMISSION

        modelBuilder.Entity<apiForVisualRiders.Models.Permission>().HasData(
            new Permission { Id = Guid.Parse("1a2fdbd4-3278-4505-920d-106a1826c6ea"), Title = "Secure system" },
            new Permission { Id = Guid.Parse("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"), Title = "Check employees health insurance" },
            new Permission { Id = Guid.Parse("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"), Title = "Check products" }
            );

        //ROLES
        modelBuilder.Entity<Role>()
                .HasOne<Permission>()
                .WithMany()
                .HasForeignKey(p => p.PermissionId);

        modelBuilder.Entity<apiForVisualRiders.Models.Role>().HasData(
            new Role { Id = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), Title = "Admin", PermissionId = Guid.Parse("1a2fdbd4-3278-4505-920d-106a1826c6ea") },
            new Role { Id = Guid.NewGuid(), Title = "Manager", PermissionId = Guid.Parse("563fcbd3-f7c3-4248-9bed-23ae255cdaf0") },
            new Role { Id = Guid.NewGuid(), Title = "Bartender", PermissionId = Guid.Parse("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f") }
            );

        //EMPLOYEE
        //kai bus sukurtos companijos reiktų šitą atkomentuoti ir į CompanyId dėti tik sukurtų Company id
        /*modelBuilder.Entity<Employee>()
            .HasOne<Company>()
            .WithMany()
            .HasForeignKey(p => p.CompanyId);*/

        modelBuilder.Entity<Employee>()
            .HasOne<Role>()
            .WithMany()
            .HasForeignKey(p => p.RoleId);

        modelBuilder.Entity<apiForVisualRiders.Models.Employee>().HasData(
            new Employee { Id = Guid.NewGuid(), Name = "Arvydas", Email = "arvydas@gmail.com", Password = "arvydas", Status = EmployeeStatus.Active, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91") },
            new Employee { Id = Guid.NewGuid(), Name = "Danielius", Email = "danielius@gmail.com", Password = "arvydas", Status = EmployeeStatus.Active, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91") },
            new Employee { Id = Guid.NewGuid(), Name = "Paulina", Email = "paulina@gmail.com", Password = "arvydas", Status = EmployeeStatus.Deleted, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91") }
            );

        //CUSTOMER
        //kai bus sukurti discountai reiktų šitą atkomentuoti ir į DiscountId dėti tik sukurtų Discountų id
        /*modelBuilder.Entity<Customer>()
            .HasOne<Discount>()
            .WithMany()
            .HasForeignKey(p => p.DiscountId);*/

        modelBuilder.Entity<apiForVisualRiders.Models.Customer>().HasData(
            new Customer { Id = Guid.NewGuid(), Name = "Dalytė", Email = "makalyte@gmail.com", Password = "makalyte123", PhoneNumber = "+3708145141", RegisterDate = DateTime.Now, Status = CustomerStatus.Active, DiscountId = Guid.NewGuid() }
            );

        modelBuilder.Entity<Order>().HasKey(c => c.Id);
        //modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(p => p.Customer);
        //modelBuilder.Entity<Order>().HasOne<Employee>().WithMany().HasForeignKey(p => p.Employee);
        //modelBuilder.Entity<Order>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        //modelBuilder.Entity<Order>().HasOne<Delivery>().WithMany().HasForeignKey(p => p.Delivery);
        modelBuilder.Entity<Order>().HasData(
           new Order { Id = Guid.NewGuid(), SubmissionDate = DateTime.Today, FulfillmentDate = DateTime.Today, Tip = 1.24m, Comment = "Nothing", Status = OrderStatus.Created, Customer = Guid.NewGuid(), Discount = Guid.NewGuid(), Employee = Guid.NewGuid() },
           new Order { Id = Guid.NewGuid(), SubmissionDate = DateTime.Today, FulfillmentDate = DateTime.Today, Tip = 1.24m, Comment = "Abcdefu", Status = OrderStatus.Returned, Customer = Guid.NewGuid(), Discount = Guid.NewGuid(), Employee = Guid.NewGuid() }
         );
        //modelBuilder.Entity<PurchasableItem>().HasOne<ItemCategory>().WithMany().HasForeignKey(p => p.ItemCategory);
        //modelBuilder.Entity<PurchasableItem>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        modelBuilder.Entity<PurchasableItem>().HasData(
            new PurchasableItem { Id = Guid.NewGuid(), Description = "Desc1", Discount = Guid.NewGuid(), Duration = 10, ItemCategory = Guid.NewGuid(), Name = "PurchItem1", Price = 5.27m, Status = PurchasableItemStatus.Active },
            new PurchasableItem { Id = Guid.NewGuid(), Description = "Desc2", Discount = Guid.NewGuid(), Duration = 7, ItemCategory = Guid.NewGuid(), Name = "PurchItem222", Price = 5.27m, Status = PurchasableItemStatus.Deleted }
         );
        //modelBuilder.Entity<ItemCategory>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        modelBuilder.Entity<ItemCategory>().HasData(
            new ItemCategory { Id = Guid.NewGuid(), Name = "Category1", Description = "somthing", Discount = Guid.NewGuid() },
            new ItemCategory { Id = Guid.NewGuid(), Name = "Category222", Description = "somthing222", Discount = Guid.NewGuid() }
         );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
