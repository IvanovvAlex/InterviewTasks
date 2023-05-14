using System;
using System.Collections.Generic;
using DevelopSoft.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopSoft.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
       .HasMany(c => c.Orders)
       .WithOne(o => o.Customer)
       .HasForeignKey(o => o.CustomerID);

    }
}
