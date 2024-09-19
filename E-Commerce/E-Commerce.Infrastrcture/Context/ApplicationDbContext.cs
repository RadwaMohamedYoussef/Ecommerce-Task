using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastrcture.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seeding roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1", 
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "StoreOwner",
                    NormalizedName = "STOREOWNER"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            );
        }

    }

}
