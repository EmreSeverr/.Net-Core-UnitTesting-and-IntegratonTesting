using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestExamples.API.Services.Abstract;
using TestExamples.API.Services.Concrate;
using TestExamples.Data;
using TestExamples.Data.Repositories.Abstract;
using TestExamples.Data.Repositories.Concrate;

namespace TestExamples.API
{
    public static class StartupConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TestExampleContext>(options => options.UseMySql(configuration["ConnectionStrings:LocalDatabase"].ToString(), new MySqlServerVersion(new Version(1, 0, 0)), o => { o.MigrationsAssembly("TestExamples.API"); }));
        }

        public static void ConfigureServices(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IUnitService, UnitService>();
            service.AddScoped<IProductCategoryService, ProductCategoryService>();
        }

        public static void ConfigureRepositories(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUnitRepository, UnitRepository>();
            service.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }

        public static async Task MigrateDatabaseAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<TestExampleContext>())
                {
                    await context.Database.MigrateAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
