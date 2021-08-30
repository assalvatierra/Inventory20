using System;
using Xunit;

using Microsoft.AspNetCore.TestHost; //TestServer //add NU Package
using System.Net.Http; //HttpClient
using Microsoft.Extensions.Configuration; //ConfigurationBuilder
using Microsoft.AspNetCore.Hosting; //WebHostBuilder
using System.Threading.Tasks; //Tasks
using System.Net;

namespace WebInv.Server.Test
{
    public class UnitTest101: IDisposable
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public UnitTest101()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseContentRoot("/");
            webBuilder.UseEnvironment("TEST123");
            webBuilder.UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
            );

            webBuilder.UseStartup<Startup>();

            server = new TestServer(webBuilder);
            this.client = this.server.CreateClient();

        }

        [Fact]
        public async void InvStore_Get_ReturnsAllStores()
        {

            HttpResponseMessage response = await this.server.CreateRequest("/api/InvStores").SendAsync("GET");
            string resultstring = await response.Content.ReadAsStringAsync();

            Assert.Contains("Cebu-Banilad", resultstring);
            Assert.Contains("Davao Bajada", resultstring);
        }

        [Fact]
        public async Task InvStore_Get_ReturnsAllStores_method2()
        {
            //var url = "https://localhost:44359/api/InvStores";

            var result = await this.client.GetAsync("/api/InvStores"); //webapi: api/InvStores; page: /StoreList
            var resultstring = await result.Content.ReadAsStringAsync();
            Assert.Contains("Cebu-Banilad", resultstring);
            Assert.Contains("Davao Bajada", resultstring);
        }

        [Theory]
        [InlineData(1, "Cebu-Banilad")]
        [InlineData(2, "Davao Bajada")]
        [InlineData(3, "Gensan")]
        [InlineData(4, "Cagayan")]
        [InlineData(5, "Makati")]
        public async Task InvStore_GetById_ReturnsAStore(int id, string keyword)
        {
            var result = await this.client.GetAsync("/api/InvStores/" + id.ToString());
            var resultstring = await result.Content.ReadAsStringAsync();
            Assert.Contains(keyword, resultstring);
        }

        public void Dispose()
        {
            client.Dispose();
            server.Dispose();
        }

    }
}
