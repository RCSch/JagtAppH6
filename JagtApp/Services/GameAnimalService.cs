using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JagtApp.Models;

namespace JagtApp.Services
{
    public class GameAnimalService
    {
        private readonly HttpClient _httpClient;

        public GameAnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GameAnimal>> GetGameAnimals()
        {
            return await _httpClient.GetFromJsonAsync<List<GameAnimal>>("api/gameanimals");
        }

        public async Task<List<GameAnimal>> GetGameAnimalsInSeasonToday()
        {
            var gameAnimals = await GetGameAnimals();
            return gameAnimals.Where(ga => ga.IsInSeasonToday()).ToList();
        }
    }
}
