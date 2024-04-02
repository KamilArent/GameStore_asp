using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Client.Models;

namespace GameStore.Client.Services
{
    public interface IGameClientService
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameAsync(int? id);
        Task AddGameAsync(GameToAdd game);
        Task UpdateGameAsync(int? id, GameToAdd game);
        Task DeleteGameAsync(int id);
    }
}