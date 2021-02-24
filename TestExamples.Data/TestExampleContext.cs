using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestExamples.Data.Entities.Concrate;

namespace TestExamples.Data
{
    public class TestExampleContext : DbContext
    {
        public TestExampleContext(DbContextOptions<TestExampleContext> dbContextOptionsBuilder) : base(dbContextOptionsBuilder)
        {

        }

        #region DbSet's

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        #endregion
    }
}
