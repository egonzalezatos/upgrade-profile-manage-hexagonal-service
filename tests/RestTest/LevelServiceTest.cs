using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace test
{
    public class LevelServiceTest : IClassFixture<WebApplicationFactory<Infrastructure.Startup>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public LevelServiceTest(WebApplicationFactory<Infrastructure.Startup> fixture, ITestOutputHelper output)
        {
            _client = fixture.CreateClient();
            _output = output;
        }

        [Fact]
        //http://localhost:80/api/Levels
        public async Task GetAllLevels()
        {
            //Start
            var response = await _client.GetAsync("api/Level");
            List<Level> Deserializer(string o) 
                => JsonConvert.DeserializeObject<List<Level>>(o);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            //Arrange
            var Out_Count = 3;
            
            //Act
            var o = await response.Content.ReadAsStringAsync();
            var list = Deserializer(o);

            //Assert
            list.Should().HaveCountGreaterOrEqualTo(Out_Count);
        }
    }
}