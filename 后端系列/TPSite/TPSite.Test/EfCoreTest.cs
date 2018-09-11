using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPSite.EntityFrameworkCore;

namespace TPSite.Test
{
    [TestClass]
    public class EfCoreTest
    {
    }

    public class EfCoreDbContextTest : EfCoreDbContext
    {
        public EfCoreDbContextTest() : base("")
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=TPSite;User ID=sa;Password=123.qweasdzxc");
            }
        }
    }
}
