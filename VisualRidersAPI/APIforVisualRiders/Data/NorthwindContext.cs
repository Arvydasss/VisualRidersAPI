using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apiForVisualRiders.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Northwind.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    //---------------------------------------------------------------
    public DbSet<Branch> Branch { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Service> Service { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        //-------------------------------------------------------------------------------
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
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
