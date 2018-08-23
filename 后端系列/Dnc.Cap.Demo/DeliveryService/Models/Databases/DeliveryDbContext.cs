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
        public DeliveryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Delivery> Deliveries { get; set; }
    }
}
