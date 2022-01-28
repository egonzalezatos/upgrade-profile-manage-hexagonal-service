using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using api.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace test
{
    public class PositionServiceTest : IClassFixture<WebApplicationFactory<api.Startup>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public PositionServiceTest(WebApplicationFactory<api.Startup> fixture, ITestOutputHelper output)
        {
            _output = output;
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetHello()
        {
            //Start
            var response = await _client.GetAsync("api");
            string Deserializer(string o) => o;
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var r = await response.Content.ReadAsStringAsync();
            
            _output.WriteLine(r);
            _output.WriteLine("Status: " + Deserializer(r));

            //Arrange
            var Out_hello = "Hello";
            
            //Act
            var hello = Deserializer(r);

            //Assert
            hello.Should().Be(Out_hello);
        }
        
        [Fact]
        public async Task GetAllPositions()
        {
            //Start
            var response = await _client.GetAsync("api/Position");
            List<JobPositionDto> Deserializer(string o) 
                => JsonConvert.DeserializeObject<List<JobPositionDto>>(o);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
                
            //Arrange
            var Out_positionCounts = 3;
            
            //Act
            var r = await response.Content.ReadAsStringAsync();
            var positions = Deserializer(r);

            //Assert
            positions.Should().HaveCountGreaterOrEqualTo(Out_positionCounts);
        }
    }
}