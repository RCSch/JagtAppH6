using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using JagtApp.Models;

public class CombinationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CombinationService> _logger;

    public CombinationService(HttpClient httpClient, ILogger<CombinationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<Combination>> GetCombinations()
    {
        _logger.LogInformation("Fetching combinations from API.");
        return await _httpClient.GetFromJsonAsync<List<Combination>>("api/combinations");
    }

    public async Task<Combination> CreateCombination(Combination combination)
    {
        _logger.LogInformation("Creating a new combination with the following details: {@Combination}", combination);
        var response = await _httpClient.PostAsJsonAsync("api/combinations", combination);

        if (response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Combination created successfully.");
            return await response.Content.ReadFromJsonAsync<Combination>();
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _logger.LogError("Failed to create combination. Status code: {StatusCode}, Reason: {ReasonPhrase}, Error Content: {ErrorContent}", response.StatusCode, response.ReasonPhrase, errorContent);
            throw new HttpRequestException($"Failed to create combination. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
        }
    }
}
