using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
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
    public class BulletServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly BulletService _bulletService;

        public BulletServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object) { BaseAddress = new Uri("https://localhost:7208/") };
            _bulletService = new BulletService(_httpClient);
        }

        [Fact]
        public async Task GetBullets_ReturnsBullets()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };

            var bullets = new List<Bullet> { new Bullet { Id = 1, BulletName = "Test Bullet", BulletWeight = 9.0 } };
            var json = JsonSerializer.Serialize(bullets, options);

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
            var result = await _bulletService.GetBullets();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test Bullet", result[0].BulletName);
        }

        [Fact]
        public async Task GetBulletById_ReturnsBullet()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };

            var bullet = new Bullet { Id = 1, BulletName = "Test Bullet", BulletWeight = 9.0 };
            var json = JsonSerializer.Serialize(bullet, options);

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
            var result = await _bulletService.GetBulletById(1);

            // Assert
            Assert.Equal("Test Bullet", result.BulletName);
        }

        [Fact]
        public async Task CreateBullet_Success()
        {
            // Arrange
            var bullet = new Bullet { Id = 1, BulletName = "Test Bullet" };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created
                });

            // Act
            await _bulletService.CreateBullet(bullet);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri == new Uri("https://localhost:7208/api/Bullets") &&
                    req.Content != null),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task UpdateBullet_Success()
        {
            // Arrange
            var bullet = new Bullet { Id = 1, BulletName = "Updated Bullet" };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            // Act
            await _bulletService.UpdateBullet(1, bullet);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put &&
                    req.RequestUri == new Uri("https://localhost:7208/api/Bullets/1") &&
                    req.Content != null),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task DeleteBullet_Success()
        {
            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            // Act
            await _bulletService.DeleteBullet(1);

            // Assert
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Delete &&
                    req.RequestUri == new Uri("https://localhost:7208/api/Bullets/1")),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
