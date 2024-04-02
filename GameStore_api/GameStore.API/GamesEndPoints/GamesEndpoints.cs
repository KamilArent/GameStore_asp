using System.Runtime.CompilerServices;
using GameStore.API.Data;
using GameStore.API.dtos;
using GameStore.API.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.GamesEndPoints
{
    public static class GamesEndPoints
    {
        const string GetGameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            //GET /games
            group.MapGet("/", async (GameStoreContext dbContext) =>
            {
                var games = await dbContext.Games
                    .Include(game => game.Genre)
                    .Select(game => game.ToDto())
                    .AsNoTracking()
                    .ToArrayAsync();

                return Results.Ok(games);
            });

            //GET /games/id
            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                Game? game = await dbContext.Games
                .Where(query => query.Id == id)
                .Include(query => query.Genre)
                .FirstOrDefaultAsync();

                return game is null ? Results.NotFound() : Results.Ok(game.ToDto());
            }).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", async (CreateGame game, GameStoreContext dbContext) =>
            {
                Game newGame = game.ToEntity(dbContext);

                dbContext.Games.Add(newGame);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.Id }, newGame.ToDto());
            });

            //PUT /games/id
            group.MapPut("/{id}", async (int id, UpdateGame updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame == null)
                    return Results.NotFound();

                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id, dbContext));

                await dbContext.SaveChangesAsync();

                return Results.Accepted();
            });

            //DELETE /games/id
            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games
                    .Where(query => query.Id == id)
                    .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
