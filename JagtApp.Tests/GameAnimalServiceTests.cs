using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using JagtApp.Models;
using JagtApp.Services;
using JagtApp.Enums;
using Moq;
using Moq.Protected;
using Xunit;

namespace JagtApp.Tests
{
    public class GameAnimalServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly GameAnimalService _gameAnimalService;

        public GameAnimalServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object) { BaseAddress = new Uri("https://localhost:7208/") };
            _gameAnimalService = new GameAnimalService(_httpClient);
        }

        [Fact]
        public async Task GetGameAnimals_ReturnsGameAnimals()
        {
            // Arrange
            var gameAnimals = new List<GameAnimal>
            {
                new GameAnimal { Id = 1, GameName = "Kronhjort", GameClass = GameClass.Klasse1 }
            };
            var json = JsonSerializer.Serialize(gameAnimals);

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            // Act
            var result = await _gameAnimalService.GetGameAnimals();

            // Assert
            Assert.Single(result);
            Assert.Equal("Kronhjort", result[0].GameName);
        }

        [Fact]
        public async Task GetGameAnimalsInSeasonToday_ReturnsGameAnimalsInSeason()
        {
            // Arrange
            var today = DateTime.Today;
            var huntingSeasons = new List<HuntingSeason>
            {
                new HuntingSeason { StartMonth = today.Month, StartDay = today.Day - 1, EndMonth = today.Month, EndDay = today.Day + 1 }
            };
            var gameAnimals = new List<GameAnimal>
            {
                new GameAnimal { Id = 17, GameName = "Råbuk", GameClass = GameClass.Klasse2, HuntingSeasons = huntingSeasons }
            };
            var json = JsonSerializer.Serialize(gameAnimals);

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            // Act
            var result = await _gameAnimalService.GetGameAnimalsInSeasonToday();

            // Assert
            Assert.Single(result);
            Assert.Equal("Råbuk", result[0].GameName);
        }
    }
}
