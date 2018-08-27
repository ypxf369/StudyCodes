using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;

namespace Demo2OrderService
{
    public class OrderDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OrderDbContext(IConfiguration configuration)
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

            modelBuilder.Entity<Order>(i =>
            {
                i.ToTable("Orders");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime);
                i.Property(p => p.IsDeleted).IsRequired();
                i.Property(p => p.PayStatus).IsRequired();
                i.Property(p => p.TotalPrices).IsRequired();
                i.HasOne(p => p.User).WithMany().HasForeignKey(k => k.UserId).IsRequired();
            });
            modelBuilder.Entity<OrderProduct>(i =>
            {
                i.ToTable("OrderProducts");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime);
                i.Property(p => p.IsDeleted).IsRequired();
                i.HasOne(p => p.Product).WithMany().HasForeignKey(k => k.ProductId).IsRequired();
                i.HasOne(p => p.Order).WithMany().HasForeignKey(k => k.OrderId).IsRequired();
            });
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
