using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class CaliberService
    {
        private readonly HttpClient _httpClient;

        public CaliberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Caliber>> GetCalibers()
        {
            return await _httpClient.GetFromJsonAsync<List<Caliber>>("api/Calibers");
        }

        public async Task<Caliber> GetCaliberById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Caliber>($"api/Calibers/{id}");
        }

        public async Task CreateCaliber(Caliber caliber)
        {
            await _httpClient.PostAsJsonAsync("api/Calibers", caliber);
        }

        public async Task UpdateCaliber(int id, Caliber caliber)
        {
            await _httpClient.PutAsJsonAsync($"api/Calibers/{id}", caliber);
        }

        public async Task DeleteCaliber(int id)
        {
            await _httpClient.DeleteAsync($"api/Calibers/{id}");
        }
    }
}
