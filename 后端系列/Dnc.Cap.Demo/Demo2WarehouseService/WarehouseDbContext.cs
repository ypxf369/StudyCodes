using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo2WarehouseService
{
    public class WarehouseDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WarehouseDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["DB:ConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Warehouse>(i =>
            {
                i.ToTable("Warehouses");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime);
                i.Property(p => p.IsDeleted).IsRequired();
                i.Property(p => p.StoreNum).IsRequired();
                i.HasOne(m => m.Product).WithMany().HasForeignKey(k => k.ProductId).IsRequired();
            });
            modelBuilder.Entity<Product>(i =>
            {
                i.ToTable("Products");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime);
                i.Property(p => p.IsDeleted).IsRequired();
                i.Property(p => p.Name).HasMaxLength(50).IsRequired();
                i.Property(p => p.Price).IsRequired();
            });
        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
