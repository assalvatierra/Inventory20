using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Xunit;

namespace WebInv.Server.Test
{
    public class UnitTest102
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        //public UnitTest102()
        //{
        //    var configuration = new ConfigurationBuilder()
        //     .AddJsonFile("appsettings.json")
        //     .Build();

        //    this.server = new TestServer(new WebHostBuilder()
        //        .UseConfiguration(configuration)
        //        .UseStartup<Startup>()
        //        );

        //    this.client = this.server.CreateClient();

        //}

        [Fact]
        public void Test102()
        {

        }

        [Fact]
        public async Task InvStoreList()
        {
            var result = await this.client.GetAsync("/vehicles");
            var resultstring = await result.Content.ReadAsStringAsync();
            Assert.Contains("11711", resultstring);
            Assert.Contains("LDP2264", resultstring);
        }

        [Fact]
        public async Task GetMyStoreId()
        {
            var result = await this.client.GetAsync("/Vehicles/Edit?id=3");
            var resultstring = await result.Content.ReadAsStringAsync();
            Assert.Contains("11711", resultstring);
            Assert.Contains("4x4", resultstring);
            Assert.DoesNotContain("LDP2264", resultstring);
        }


    }
}
