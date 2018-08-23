using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StorageService.Models.Entities;

namespace StorageService.Models.Databases
{
    public class StorageDbContext : DbContext
    {
        public string ConnStr { get; set; }

        public StorageDbContext(DbContextOptions options, string connStr) : base(options)
        {
            ConnStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnStr);
        }

        public DbSet<Storage> Storages { get; set; }
    }
}
