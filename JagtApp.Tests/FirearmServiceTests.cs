using Xunit;
using Moq;
using JagtApp.Services;
using JagtApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Json;
using Moq.Protected;

namespace JagtApp.Tests
{
    public class FirearmServiceTests
    {
        [Fact]
        public async Task GetFirearms_ReturnsFirearmsList()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(new List<Firearm>
                    {
                        new Firearm { Id = 1, FAName = "Rifle A" },
                        new Firearm { Id = 2, FAName = "Rifle B" }
                    })
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new System.Uri("https://localhost:7208")
            };

            var service = new FirearmService(httpClient);

            // Act
            var result = await service.GetFirearms();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
