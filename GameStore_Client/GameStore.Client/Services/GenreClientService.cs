using System.Net.Http.Json;
using GameStore.Client.Models;

namespace GameStore.Client.Services
{
    public class GenreClientServices : IGenreClientService
    {
        private readonly HttpClient httpClient;
        private readonly static string map = "genres";

        public GenreClientServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            var response = await httpClient.GetAsync(map);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Genre>>();
            }
            else
            {
                return Enumerable.Empty<Genre>(); //obsułga nie udanej operacji
            }
        }
    }
}