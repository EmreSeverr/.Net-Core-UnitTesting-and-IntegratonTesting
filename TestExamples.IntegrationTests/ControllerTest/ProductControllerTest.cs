using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestExamples.API.DTOs;
using TestExamples.InitializeDatas;
using Xunit;

namespace TestExamples.IntegrationTests.ControllerTest
{
    public class ProductControllerTest
    {
        private readonly HttpClient _httpclient;

        public ProductControllerTest()
        {
            var testServer = new TestServer(new WebHostBuilder()
                .UseStartup<FakeStartup>()
                .UseEnvironment("Development"));
            _httpclient = testServer.CreateClient();
        }

        [Theory]
        [InlineData("api/Product")]
        public async Task Deneme(string getUrl)
        {
            await SeedData.ResetAllDatas().ConfigureAwait(false);

            var responseGet = await _httpclient.GetAsync(getUrl).ConfigureAwait(false);

            var result = await responseGet.Content.ReadAsStringAsync().ConfigureAwait(false);
            var response = JsonConvert.DeserializeObject<List<ProductDTO>>(result);

            var expectedCount = 4;

            Assert.Equal(expectedCount, response.Count);
        }
    }
}
