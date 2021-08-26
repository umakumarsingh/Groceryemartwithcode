using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryEmart.DataLayer
{
    public class GroceryemartDbContext :DbContext
    {
        public GroceryemartDbContext(DbContextOptions<GroceryemartDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Seed and create DbSet for all loan class
        /// </summary>
        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductOrder> productOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasKey(x => x.UserId);
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Product>().HasKey(x => x.ProductId);
            builder.Entity<ProductOrder>().HasKey(x => x.OrderId);
            base.OnModelCreating(builder);
        }
    }
}
