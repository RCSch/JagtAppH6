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
using Moq;
using Moq.Protected;
using Xunit;

namespace JagtApp.Tests
{
    public class CaliberServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly CaliberService _caliberService;

        public CaliberServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object) { BaseAddress = new Uri("https://localhost:7208/") };
            _caliberService = new CaliberService(_httpClient);
        }

        [Fact]
        public async Task GetCalibers_ReturnsCalibers()
        {
            // Arrange
            var calibers = new List<Caliber>
            {
                new Caliber { Id = 1, CaliberName = ".308 Winchester", CaliberDiameter = 7.62 }
            };
            var json = JsonSerializer.Serialize(calibers);

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
            var result = await _caliberService.GetCalibers();

            // Assert
            Assert.Single(result);
            Assert.Equal(".308 Winchester", result[0].CaliberName);
        }

        [Fact]
        public async Task GetCaliberById_ReturnsCaliber()
        {
            // Arrange
            var caliber = new Caliber { Id = 1, CaliberName = ".308 Winchester", CaliberDiameter = 7.62 };
            var json = JsonSerializer.Serialize(caliber);

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
            var result = await _caliberService.GetCaliberById(1);

            // Assert
            Assert.Equal(".308 Winchester", result.CaliberName);
        }

        [Fact]
        public async Task CreateCaliber_Success()
        {
            // Arrange
            var caliber = new Caliber { Id = 1, CaliberName = ".308 Winchester", CaliberDiameter = 7.62 };

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post && req.RequestUri == new Uri("https://localhost:7208/api/Calibers")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created
                });

            // Act
            await _caliberService.CreateCaliber(caliber);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task UpdateCaliber_Success()
        {
            // Arrange
            var caliber = new Caliber { Id = 1, CaliberName = ".308 Winchester", CaliberDiameter = 7.62 };

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put && req.RequestUri == new Uri("https://localhost:7208/api/Calibers/1")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            // Act
            await _caliberService.UpdateCaliber(1, caliber);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Put),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task DeleteCaliber_Success()
        {
            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Delete && req.RequestUri == new Uri("https://localhost:7208/api/Calibers/1")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            // Act
            await _caliberService.DeleteCaliber(1);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
