using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestExamples.API.Services.Abstract;
using TestExamples.API.Services.Concrate;
using TestExamples.Data;
using TestExamples.Data.Repositories.Abstract;
using TestExamples.Data.Repositories.Concrate;
using TestExamples.InitializeDatas;
using Xunit;

namespace TestExamples.UnitTests.ServiceTests
{
    public class ProductServiceTest
    {
        private readonly IProductService _productService;

        public ProductServiceTest()
        {
            _productService = MockProductService();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1000)]
        [InlineData(1)]
        public async Task DeleteProductTest(int id)
        {
            await SeedData.ResetAllDatas().ConfigureAwait(false);

            await _productService.DeleteByIdProductAsync(id).ConfigureAwait(false);
        }

        [Fact]
        public async Task GetAllProductAsyncTest()
        {
            await SeedData.ResetAllDatas().ConfigureAwait(false);

            var allEntities = await _productService.GetAllProductAsync().ConfigureAwait(false);

            var expectedCount = 4;

            Assert.Equal(expectedCount, allEntities.Count);
        }




        private IProductService MockProductService()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<TestExampleContext>(options => options.UseMySql("server=localhost;port=3306;database=testExample;uid=root;password=root;CharSet=utf8;Convert Zero Datetime=true; Allow Zero Datetime=true", new MySqlServerVersion(new Version(1, 0, 0)), o => { o.MigrationsAssembly("TestExamples.API"); }));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services.BuildServiceProvider().GetRequiredService<IProductService>();
        }
    }
}
