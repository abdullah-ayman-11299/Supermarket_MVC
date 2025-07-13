using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Seeding Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Beverage",Description= "Beverage" },
                new Category { Id=2,Name="Bakery",Description= "Bakery" },
                new Category { Id=3,Name="Meat",Description= "Meat" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product{ Id = 1,CategoryId = 1,Name="Ice Tea",Quantity=100,Price=1.99},
                new Product{ Id = 2,CategoryId = 1,Name="Canada Dry",Quantity=100,Price=1.99},
                new Product{ Id = 3,CategoryId = 2,Name= "Water", Quantity=300,Price=1.99},
                new Product{ Id = 4,CategoryId = 2,Name="OnePiece",Quantity=1,Price=9999}
                );
        }
    }
}
