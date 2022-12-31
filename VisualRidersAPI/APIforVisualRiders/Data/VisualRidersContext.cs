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
    public DbSet<Product> Product { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Discount> Discount { get; set; }

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
        modelBuilder.Entity<Service>().HasOne<Discount>().WithMany().HasForeignKey(p => p.DiscountId);
        modelBuilder.Entity<Service>().HasOne<Branch>().WithMany().HasForeignKey(p => p.BranchId);
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = Guid.NewGuid(), Name = "ServiceName", Description = "Service1Description", Price = 12.34m, Status = ServiceStatus.Active, DiscountId = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), BranchId = Guid.Parse("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6") },
            new Service { Id = Guid.Parse("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"), Name = "ServiceName2", Description = "Service2Description", Price = 10.23m, Status = ServiceStatus.Active, DiscountId = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), BranchId = Guid.Parse("f7517440-4dc6-4fe3-8f0f-80fdfd1d35f6") }
          );

        //PERMISSION
        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = Guid.Parse("1a2fdbd4-3278-4505-920d-106a1826c6ea"), Title = "Secure system" },
            new Permission { Id = Guid.Parse("563fcbd3-f7c3-4248-9bed-23ae255cdaf0"), Title = "Check employees health insurance" },
            new Permission { Id = Guid.Parse("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f"), Title = "Check products" }
            );

        //ROLES
        modelBuilder.Entity<Role>().HasOne<Permission>().WithMany().HasForeignKey(p => p.PermissionId);
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), Title = "Admin", PermissionId = Guid.Parse("1a2fdbd4-3278-4505-920d-106a1826c6ea") },
            new Role { Id = Guid.NewGuid(), Title = "Manager", PermissionId = Guid.Parse("563fcbd3-f7c3-4248-9bed-23ae255cdaf0") },
            new Role { Id = Guid.NewGuid(), Title = "Bartender", PermissionId = Guid.Parse("d6e76701-49ca-4a6d-ba44-e7cdfc73ff1f") }
            );

        //EMPLOYEE
        modelBuilder.Entity<Employee>().HasOne<Company>().WithMany().HasForeignKey(p => p.CompanyId);
        modelBuilder.Entity<Employee>().HasOne<Role>().WithMany().HasForeignKey(p => p.RoleId);
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = Guid.NewGuid(), Name = "Arvydas", Email = "arvydas@gmail.com", Password = "arvydas", Status = EmployeeStatus.Active, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), CompanyId = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669") },
            new Employee { Id = Guid.NewGuid(), Name = "Danielius", Email = "danielius@gmail.com", Password = "arvydas", Status = EmployeeStatus.Active, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), CompanyId = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669") },
            new Employee { Id = Guid.NewGuid(), Name = "Paulina", Email = "paulina@gmail.com", Password = "arvydas", Status = EmployeeStatus.Deleted, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), CompanyId = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669") },
            new Employee { Id = Guid.Parse("32d71bbb-0bb6-4d22-b3e0-14ef0795b007"), Name = "Rokas", Email = "rokas@gmail.com", Password = "rokas", Status = EmployeeStatus.Active, RoleId = Guid.Parse("56959975-10b8-4199-b4b1-5705d82eba91"), CompanyId = Guid.Parse("d1ce4e4b-813f-4c89-9440-19cfb83a7669") }
            );

        //CUSTOMER
        modelBuilder.Entity<Customer>().HasOne<Discount>().WithMany().HasForeignKey(p => p.DiscountId);
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = Guid.NewGuid(), Name = "Dalytė", Email = "makalyte@gmail.com", Password = "makalyte123", PhoneNumber = "+3708145141", RegisterDate = DateTime.Now, Status = CustomerStatus.Active, DiscountId = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b") },
            new Customer { Id = Guid.Parse("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), Name = "Petras", Email = "petr@gmail.com", Password = "petriok123", PhoneNumber = "+370812252", RegisterDate = DateTime.Now, Status = CustomerStatus.Active, DiscountId = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b") }
            );

        //ORDER
        modelBuilder.Entity<Order>().HasKey(c => c.Id);
        modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(p => p.Customer);
        modelBuilder.Entity<Order>().HasOne<Employee>().WithMany().HasForeignKey(p => p.Employee);
        modelBuilder.Entity<Order>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        //modelBuilder.Entity<Order>().HasOne<Delivery>().WithMany().HasForeignKey(p => p.Delivery);
        modelBuilder.Entity<Order>().HasData(
           new Order { Id = Guid.NewGuid(), SubmissionDate = DateTime.Today, FulfillmentDate = DateTime.Today, Tip = 1.24m, Comment = "Nothing", Status = OrderStatus.Created, Customer = Guid.Parse("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Employee = Guid.Parse("32d71bbb-0bb6-4d22-b3e0-14ef0795b007") },
           new Order { Id = Guid.NewGuid(), SubmissionDate = DateTime.Today, FulfillmentDate = DateTime.Today, Tip = 1.24m, Comment = "Abcdefu", Status = OrderStatus.Returned, Customer = Guid.Parse("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Employee = Guid.Parse("32d71bbb-0bb6-4d22-b3e0-14ef0795b007") },
           new Order { Id = Guid.Parse("eceba813-ac14-4e03-b5e3-756bae902441"), SubmissionDate = DateTime.Today, FulfillmentDate = DateTime.Today, Tip = 1.24m, Comment = "Woop", Status = OrderStatus.Returned, Customer = Guid.Parse("7e3de3f7-826f-49e0-bad4-e996d92a0d88"), Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Employee = Guid.Parse("32d71bbb-0bb6-4d22-b3e0-14ef0795b007") }
         );

        //PURCHASABLEITEM
        modelBuilder.Entity<PurchasableItem>().HasOne<ItemCategory>().WithMany().HasForeignKey(p => p.ItemCategory);
        modelBuilder.Entity<PurchasableItem>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        modelBuilder.Entity<PurchasableItem>().HasData(
            new PurchasableItem { Id = Guid.NewGuid(), Description = "Desc1", Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Duration = 10, ItemCategory = Guid.Parse("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), Name = "PurchItem1", Price = 5.27m, Status = PurchasableItemStatus.Active },
            new PurchasableItem { Id = Guid.NewGuid(), Description = "Desc2", Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Duration = 7, ItemCategory = Guid.Parse("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), Name = "PurchItem222", Price = 5.27m, Status = PurchasableItemStatus.Deleted }
         );

        //ITEMCATEGORY
        modelBuilder.Entity<ItemCategory>().HasOne<Discount>().WithMany().HasForeignKey(p => p.Discount);
        modelBuilder.Entity<ItemCategory>().HasData(
            new ItemCategory { Id = Guid.Parse("e62f5c00-0c9c-4ce6-ac4f-ecb50d621f47"), Name = "Category1", Description = "somthing", Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b") },
            new ItemCategory { Id = Guid.NewGuid(), Name = "Category222", Description = "somthing222", Discount = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b") }
         );

        //RESERVATION
        modelBuilder.Entity<Reservation>().HasKey(c => c.Id);
        modelBuilder.Entity<Reservation>().HasOne<Employee>().WithMany().HasForeignKey(p => p.EmployeeId);
        modelBuilder.Entity<Reservation>().HasOne<Service>().WithMany().HasForeignKey(p => p.ServiceId);
        modelBuilder.Entity<Reservation>().HasOne<Order>().WithMany().HasForeignKey(p => p.OrderId);
        modelBuilder.Entity<Reservation>().HasData(
            new Reservation { Id = Guid.NewGuid(), StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(3), ReservationStatus = ReservationStatus.Submitted, ServiceId = Guid.Parse("c4559b26-d0b9-4f47-b0b5-dfafd7a70b61"), OrderId = Guid.Parse("eceba813-ac14-4e03-b5e3-756bae902441"), EmployeeId = Guid.Parse("32d71bbb-0bb6-4d22-b3e0-14ef0795b007") }
          );

        //DISCOUNT
        modelBuilder.Entity<Discount>().HasData(
            new Discount { Id = Guid.NewGuid(), Amount = 20, Measure = DiscountMeasure.Absolute, Code = "NUOLAIDA20", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) },
            new Discount { Id = Guid.Parse("70163c24-2c08-4924-a2a2-abb4e2079a0b"), Amount = 30, Measure = DiscountMeasure.Absolute, Code = "NUOLAIDA30", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) }
          );

        //PRODUCT
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Name = "Cabbage" }
          );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
