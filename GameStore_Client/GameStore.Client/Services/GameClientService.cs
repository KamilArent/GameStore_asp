using System.Net.Http.Json;
using GameStore.Client.Models;

namespace GameStore.Client.Services
{
    public class GameClientService : IGameClientService
    {
        private readonly HttpClient httpClient;
        private static readonly string map = "games";
        public GameClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var response = await httpClient.GetAsync(map);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Game>>();
            }
            else
            {
                return null; //obsułga nie udanej operacji
            }
        }

        public async Task<Game> GetGameAsync(int? id)
        {
            var response = await httpClient.GetAsync($"{map}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Game>();
            }
            else
            {
                return null;
            }
        }

        public async Task AddGameAsync(GameToAdd game)
        {
            var response = await httpClient.PostAsJsonAsync(map, game);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGameAsync(int? id, GameToAdd game)
        {
            var response = await httpClient.PutAsJsonAsync($"{map}/{id}", game);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGameAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{map}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}