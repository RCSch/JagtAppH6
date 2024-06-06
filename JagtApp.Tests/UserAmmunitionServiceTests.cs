using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using JagtApp.Models;
using JagtApp.Services;
using System.Net.Http.Json;
using System.Collections.Generic;

public class UserAmmunitionServiceTests
{
    private readonly HttpClient _httpClient;
    private readonly UserAmmunitionService _userAmmunitionService;

    public UserAmmunitionServiceTests()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        _userAmmunitionService = new UserAmmunitionService(_httpClient);
    }

    [Fact]
    public async Task GetUserAmmunition_ReturnsUserAmmunition()
    {
        // Arrange
        var userAmmunitionList = new List<UserAmmunition>
        {
            new UserAmmunition { Id = 1, CartridgeId = 1, Quantity = 100, OwnerId = "owner1" },
            new UserAmmunition { Id = 2, CartridgeId = 2, Quantity = 200, OwnerId = "owner2" }
        };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.OK,
               Content = JsonContent.Create(userAmmunitionList)
           });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        var userAmmunitionService = new UserAmmunitionService(httpClient);

        // Act
        var result = await userAmmunitionService.GetUserAmmunition();

        // Assert
        Assert.Equal(userAmmunitionList.Count, result.Count);
    }

    [Fact]
    public async Task GetUserAmmunitionById_ReturnsUserAmmunition()
    {
        // Arrange
        var userAmmunition = new UserAmmunition { Id = 1, CartridgeId = 1, Quantity = 100, OwnerId = "owner1" };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.OK,
               Content = JsonContent.Create(userAmmunition)
           });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        var userAmmunitionService = new UserAmmunitionService(httpClient);

        // Act
        var result = await userAmmunitionService.GetUserAmmunitionById(1);

        // Assert
        Assert.Equal(userAmmunition.Id, result.Id);
    }

    [Fact]
    public async Task CreateUserAmmunition_Success()
    {
        // Arrange
        var newUserAmmunition = new UserAmmunition { CartridgeId = 1, Quantity = 100, OwnerId = "owner1" };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.Created
           });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        var userAmmunitionService = new UserAmmunitionService(httpClient);

        // Act
        await userAmmunitionService.CreateUserAmmunition(newUserAmmunition);

        // Assert
        handlerMock.Protected().Verify(
           "SendAsync",
           Times.Once(),
           ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
           ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task UpdateUserAmmunition_Success()
    {
        // Arrange
        var updateUserAmmunition = new UserAmmunition { Id = 1, CartridgeId = 1, Quantity = 150, OwnerId = "owner1" };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Put),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.NoContent
           });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        var userAmmunitionService = new UserAmmunitionService(httpClient);

        // Act
        await userAmmunitionService.UpdateUserAmmunition(updateUserAmmunition.Id, updateUserAmmunition);

        // Assert
        handlerMock.Protected().Verify(
           "SendAsync",
           Times.Once(),
           ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Put),
           ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task DeleteUserAmmunition_Success()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.NoContent
           });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7208/")
        };
        var userAmmunitionService = new UserAmmunitionService(httpClient);

        // Act
        await userAmmunitionService.DeleteUserAmmunition(1);

        // Assert
        handlerMock.Protected().Verify(
           "SendAsync",
           Times.Once(),
           ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete),
           ItExpr.IsAny<CancellationToken>()
        );
    }
}
