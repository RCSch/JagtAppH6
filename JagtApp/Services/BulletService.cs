using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class BulletService
    {
        private readonly HttpClient _httpClient;

        public BulletService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Bullet>> GetBullets()
        {
            return await _httpClient.GetFromJsonAsync<List<Bullet>>("api/Bullets");
        }

        public async Task<Bullet> GetBulletById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Bullet>($"api/Bullets/{id}");
        }

        public async Task CreateBullet(Bullet bullet)
        {
            await _httpClient.PostAsJsonAsync("api/Bullets", bullet);
        }

        public async Task UpdateBullet(int id, Bullet bullet)
        {
            await _httpClient.PutAsJsonAsync($"api/Bullets/{id}", bullet);
        }

        public async Task DeleteBullet(int id)
        {
            await _httpClient.DeleteAsync($"api/Bullets/{id}");
        }
    }
}
