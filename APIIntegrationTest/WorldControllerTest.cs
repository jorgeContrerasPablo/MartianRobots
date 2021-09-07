using API;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using ServiceLayer.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace APIIntegrationTest
{
    public class WorldControllertest : IDisposable
    {
        private readonly TestServer _testServer;
        public WorldControllertest()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseEnvironment("Testing");
            webBuilder.UseStartup<TestStartup>();

            _testServer = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }

        [Fact]
        public async System.Threading.Tasks.Task StartWorldAsync()
        {            
            InputPositionDto inputPositionDto = new InputPositionDto()
            {
                X = 1,
                Y = 1,
            };

            var json = JsonConvert.SerializeObject(inputPositionDto);

            HttpContent inputPosition = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _testServer.CreateClient();
            var response = await client.PutAsync("/api/world/startworld", inputPosition);

            response.EnsureSuccessStatusCode().StatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact (Skip = "not implemented yet")]
        public async System.Threading.Tasks.Task StartRobotAsync()
        {
            InputPositionDto inputPositionDto = new InputPositionDto()
            {
                X = 1,
                Y = 1,
            };

            var json = JsonConvert.SerializeObject(inputPositionDto);

            HttpContent inputPosition = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _testServer.CreateClient();
            var response = await client.PutAsync("/api/world/startworld", inputPosition);

            response.EnsureSuccessStatusCode().StatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact (Skip = "not implemented yet")]
        public async System.Threading.Tasks.Task MoveRobotAsync()
        {
            InputPositionDto inputPositionDto = new InputPositionDto()
            {
                X = 1,
                Y = 1,
            };

            var json = JsonConvert.SerializeObject(inputPositionDto);

            HttpContent inputPosition = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _testServer.CreateClient();
            var response = await client.PutAsync("/api/world/startworld", inputPosition);

            response.EnsureSuccessStatusCode().StatusCode.Should().Equals(HttpStatusCode.OK);
        }
    }
}
