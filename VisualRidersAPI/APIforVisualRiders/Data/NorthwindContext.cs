using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using APIforVisualRiders.Models;

namespace Northwind.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public DbSet<ItemCategory> ItemCategory { get; set; }

    public  DbSet<Order> Order { get; set; }

    public  DbSet<PurchasableItem> PurchasableItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
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
