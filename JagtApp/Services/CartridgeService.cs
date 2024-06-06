﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class CartridgeService
    {
        private readonly HttpClient _httpClient;

        public CartridgeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cartridge>> GetCartridges()
        {
            return await _httpClient.GetFromJsonAsync<List<Cartridge>>("api/Cartridges");
        }

        public async Task<Cartridge> GetCartridgeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Cartridge>($"api/Cartridges/{id}");
        }

        public async Task CreateCartridge(Cartridge cartridge)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Cartridges", cartridge);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error creating cartridge: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task UpdateCartridge(int id, Cartridge cartridge)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Cartridges/{id}", cartridge);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error updating cartridge: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task DeleteCartridge(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Cartridges/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error deleting cartridge: {response.StatusCode}, {errorContent}");
            }
        }
    }
}