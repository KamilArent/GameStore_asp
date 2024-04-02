using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Client.Models;

namespace GameStore.Client.Services
{
    public interface IGenreClientService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}