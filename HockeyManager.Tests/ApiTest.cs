using HockeyManager.APIs;
using HockeyManager.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HockeyManager.Tests
{
    public class ApiTest
    {
        [Fact]
        public async void GetPlayers_ShouldReturnList()
        {
            //Arrange
            var api = new Mock<HttpClient>(); 
            var sut = new NhlApi(api.Object);
            //Act
            var result = await sut.GetPlayers();
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void TestFunctionsOfApi()
        {
            //Arrange
            var httpClient = new HttpClient();
            //Act
            string json = await httpClient.GetStringAsync("https://statsapi.web.nhl.com/api/v1/teams/1?expand=team.roster");
            Teams players = JsonConvert.DeserializeObject<Teams>(json);
            //Assert
            Assert.NotNull(json);
            Assert.NotNull(players);
        }
    }
}
