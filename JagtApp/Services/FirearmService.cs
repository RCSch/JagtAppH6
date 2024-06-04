using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class FirearmService
    {
        private readonly HttpClient _httpClient;

        public FirearmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Firearm>> GetFirearms()
        {
            return await _httpClient.GetFromJsonAsync<List<Firearm>>("api/Firearms");
        }

        public async Task<Firearm> GetFirearmById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Firearm>($"api/Firearms/{id}");
        }

        public async Task CreateFirearm(Firearm firearm)
        {
            await _httpClient.PostAsJsonAsync("api/Firearms", firearm);
        }

        public async Task UpdateFirearm(int id, Firearm firearm)
        {
            await _httpClient.PutAsJsonAsync($"api/Firearms/{id}", firearm);
        }

        public async Task DeleteFirearm(int id)
        {
            await _httpClient.DeleteAsync($"api/Firearms/{id}");
        }

        public async Task<List<Caliber>> GetCalibers()
        {
            return await _httpClient.GetFromJsonAsync<List<Caliber>>("api/Calibers");
        }
    }
}
