using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class UserAmmunitionService
    {
        private readonly HttpClient _httpClient;

        public UserAmmunitionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserAmmunition>> GetUserAmmunition()
        {
            return await _httpClient.GetFromJsonAsync<List<UserAmmunition>>("api/UserAmmunition");
        }

        public async Task<UserAmmunition> GetUserAmmunitionById(int id)
        {
            return await _httpClient.GetFromJsonAsync<UserAmmunition>($"api/UserAmmunition/{id}");
        }

        public async Task CreateUserAmmunition(UserAmmunition userAmmunition)
        {
            await _httpClient.PostAsJsonAsync("api/UserAmmunition", userAmmunition);
        }

        public async Task UpdateUserAmmunition(int id, UserAmmunition userAmmunition)
        {
            await _httpClient.PutAsJsonAsync($"api/UserAmmunition/{id}", userAmmunition);
        }

        public async Task DeleteUserAmmunition(int id)
        {
            await _httpClient.DeleteAsync($"api/UserAmmunition/{id}");
        }

        public async Task<List<Cartridge>> GetCartridges()
        {
            return await _httpClient.GetFromJsonAsync<List<Cartridge>>("api/Cartridges");
        }
    }
}
