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
    public class TechnologyServiceTest
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public TechnologyServiceTest(ITestOutputHelper output, WebApplicationFactory<api.Startup> fixture)
        {
            _output = output;
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetAllLevels()
        {
            //Start
            var response = await _client.GetAsync("api/Technology");
            List<TechnologyDto> Deserializer(string o) 
                => JsonConvert.DeserializeObject<List<TechnologyDto>>(o);
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