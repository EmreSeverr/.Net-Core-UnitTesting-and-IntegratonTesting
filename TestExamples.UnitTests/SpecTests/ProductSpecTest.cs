using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamples.API.Spec;
using TestExamples.Data.Entities.Concrate;
using TestExamples.Exceptions;
using Xunit;

namespace TestExamples.UnitTests.SpecTests
{
    public class ProductSpecTest
    {
        [Fact]
        public void GetfilteredProducts_1()
        {
            var products = GetFakeProducts();

            ProductSpec productSpec = new ProductSpec
            {
                Name = "Coca"
            };

            var actual = productSpec.GetfilteredProducts(products);

            var expectedCount = 2;

            Assert.Equal(expectedCount, actual.Count);
        }

        [Fact]
        public void test2()
        {
            ProductSpec productSpec = new ProductSpec
            {
                Name = "Coca"
            };

            Assert.Throws<TestExamplesException>(() => productSpec.GetfilteredProducts(null));
        }

        [Fact]
        public void test3()
        {
            var products = new List<Product>();

            ProductSpec productSpec = new ProductSpec
            {
                Name = "Coca"
            };

            var actual = productSpec.GetfilteredProducts(products);

            var expected = 0;

            Assert.Equal(expected, actual.Count);
        }

        public List<Product> GetFakeProducts()
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

            return products;
        }

    }
}
