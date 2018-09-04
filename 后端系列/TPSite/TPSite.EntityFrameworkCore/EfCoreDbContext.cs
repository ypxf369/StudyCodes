using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TPSite.EntityFrameworkCore
{
    public partial class EfCoreDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EfCoreDbContext()
        {
            
        }
        public EfCoreDbContext(IConfiguration configuration)
        {
            //Database.EnsureCreated();
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["DB:ConnectionString"]);
                //optionsBuilder.UseLazyLoadingProxies();//启用EFCore的延迟加载(建议不启用，显式Includ)
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("TPSite.Domain"));
        }


    }
}
