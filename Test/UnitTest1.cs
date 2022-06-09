using ConceptsCSharp_And_ASPNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class WarehouseTest
    {
        private readonly ITestOutputHelper _outputHelper;
        //private readonly WebApplicationFactory<Program> _factory;

        public WarehouseTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public async void TestGetWarehouses()
        {
            //Arrange
            var application = new MyWebApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.GetAsync("/WeatherForecast/GetWarehouses");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));


        }
    }

    class MyWebApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // shared extra set up goes here
            return base.CreateHost(builder);
        }
    }
}