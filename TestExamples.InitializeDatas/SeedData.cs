using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestExamples.Data;
using TestExamples.Data.Entities.Concrate;

namespace TestExamples.InitializeDatas
{
    public static class SeedData
    {
        public static async Task ResetAllDatas()
        {
            await ResetUnits().ConfigureAwait(false);
            await ResetCategories().ConfigureAwait(false);
            await ResetProducts().ConfigureAwait(false);
        }


        private static async Task ResetDatas<TEntity>(List<TEntity> entities) where TEntity : class
        {
            IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var connectionString = configuration.GetConnectionString("LocalDatabase");

            var options = new DbContextOptionsBuilder<TestExampleContext>()
                             .UseMySql(configuration["ConnectionStrings:LocalDatabase"].ToString(), new MySqlServerVersion(new Version(1, 0, 0)), o => { o.MigrationsAssembly("TestExamples.API"); })
                             .Options;

            using (var context = new TestExampleContext(options))
            {
                await context.Database.MigrateAsync().ConfigureAwait(false);

                var allEntities = await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
                context.Set<TEntity>().RemoveRange(allEntities);
                await context.SaveChangesAsync().ConfigureAwait(false);

                await context.Set<TEntity>().AddRangeAsync(entities).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static async Task ResetUnits()
        {
            var units = new List<Unit>
            {
                new Unit
                {
                    Id = 1,
                    Name = "Adet",
                    InsertedDate = DateTime.Now
                },
                new Unit
                {
                    Id = 2,
                    Name = "Kg",
                    InsertedDate = DateTime.Now
                }
            };

            await ResetDatas(units).ConfigureAwait(false);
        }

        private static async Task ResetCategories()
        {
            var productCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    Id = 1,
                    Name = "İçecekler",
                    InsertedDate = DateTime.Now
                },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Kuru Yemişler",
                    InsertedDate = DateTime.Now
                }
            };

            await ResetDatas(productCategories).ConfigureAwait(false);
        }

        private static async Task ResetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Coca Cola 2.5L",
                    Barcode = "12345679",
                    PurchasePrice = 4,
                    UnitPrice = 7,
                    StockAmount = 150,
                    InsertedDate = DateTime.Now,
                    UnitId = 1,
                    ProductCategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Çiğdem",
                    Barcode = "36982147",
                    PurchasePrice = 1,
                    UnitPrice = 2,
                    StockAmount = 150,
                    InsertedDate = DateTime.Now,
                    UnitId = 2,
                    ProductCategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Coca Cola 1.5L",
                    Barcode = "85485231251",
                    PurchasePrice = 2,
                    UnitPrice = 5,
                    StockAmount = 150,
                    InsertedDate = DateTime.Now,
                    UnitId = 1,
                    ProductCategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Zeytin",
                    Barcode = "74485454515",
                    PurchasePrice = 10,
                    UnitPrice = 15,
                    StockAmount = 150,
                    InsertedDate = DateTime.Now,
                    UnitId = 2,
                    ProductCategoryId = 2
                }
            };

            await ResetDatas(products).ConfigureAwait(false);
        }
    }
}
