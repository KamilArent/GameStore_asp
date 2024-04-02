using GameStore.API.Data;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.GamesEndPoints;
public static class GenresEndPoints
{
    public static RouteGroupBuilder MapGenresEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        //GET /genres
        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Genres
        .Select(genre => genre.ToDto())
        .AsNoTracking()
        .ToArrayAsync()
        );

        return group;
    }
}
