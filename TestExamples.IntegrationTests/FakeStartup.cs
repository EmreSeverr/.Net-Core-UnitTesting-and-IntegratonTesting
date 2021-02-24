using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TestExamples.API;

namespace TestExamples.IntegrationTests
{
    public class FakeStartup
    {
        public FakeStartup()
        {
            Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.ConfigureDbContext(Configuration);

            services.ConfigureServices();

            services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);

            services.ConfigureRepositories();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MigrateDatabaseAsync().Wait();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
