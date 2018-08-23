using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Models.Databases
{
    public class DeliveryDbContext : DbContext
    {
        public string ConnStr { get; set; }
        public DeliveryDbContext(DbContextOptions options, string connStr) : base(options)
        {
            ConnStr = connStr;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnStr);
        }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
