using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TPSite.Domain.Entities;

namespace TPSite.EntityFrameworkCore
{
    public partial class EfCoreDbContext : DbContext
    {
        private readonly IConfigurationRoot _configurationRoot;

        public EfCoreDbContext()
        {
            _configurationRoot = new ConfigurationBuilder().Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true }).Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configurationRoot.GetSection("DB:SqlServer:ConnectionString").Value);
                //optionsBuilder.UseLazyLoadingProxies();//启用EFCore的延迟加载(建议不启用，显式Includ)
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("TPSite.Domain"));
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
