using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Models.Entities;

namespace OrderService.Models.Databases
{
    public class OrderDbContext : DbContext
    {
        public string ConnStr { get; }

        public OrderDbContext(DbContextOptions options, string connStr) : base(options)
        {
            ConnStr = connStr;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
    }
}
