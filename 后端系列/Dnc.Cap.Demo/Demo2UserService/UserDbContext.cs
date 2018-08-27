using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo2UserService
{
    public class UserDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public UserDbContext(IConfiguration configuration)
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
            modelBuilder.Entity<User>(i =>
            {
                i.ToTable("Users");
                i.HasKey(p => p.Id);
                i.Property(p => p.CreateTime).IsRequired();
                i.Property(p => p.Creator).HasMaxLength(50).IsRequired();
                i.Property(p => p.UpdateTime).IsRequired(false);
                i.Property(p => p.IsDeleted).IsRequired();
                i.Property(p => p.UserName).HasMaxLength(50).IsRequired();
                i.Property(p => p.Balance).IsRequired();
                i.Property(p => p.Mobile).HasMaxLength(20).IsRequired();
                i.Property(p => p.Address).HasMaxLength(100).IsRequired();
            });
        }

        public DbSet<User> Users { get; set; }
    }
}
