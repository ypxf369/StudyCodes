using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo2BusineAccount
{
    public class BusineAccountDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BusineAccountDbContext(IConfiguration configuration)
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

            modelBuilder.Entity<Entity.BusineAccount>(i =>
            {
                i.ToTable("BusineAccounts");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime).IsRequired(false);
                i.Property(p => p.IsDeleted).IsRequired();
                i.Property(p => p.Balance).IsRequired();
            });
        }

        public DbSet<Entity.BusineAccount> BusineAccounts { get; set; }
    }
}
