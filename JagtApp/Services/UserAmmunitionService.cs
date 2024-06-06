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
            var response = await _httpClient.PostAsJsonAsync("api/UserAmmunition", userAmmunition);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error creating user ammunition: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task UpdateUserAmmunition(int id, UserAmmunition userAmmunition)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/UserAmmunition/{id}", userAmmunition);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error updating user ammunition: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task DeleteUserAmmunition(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/UserAmmunition/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error deleting user ammunition: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
