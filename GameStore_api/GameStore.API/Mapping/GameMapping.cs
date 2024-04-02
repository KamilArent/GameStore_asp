using GameStore.API.Data;
using GameStore.API.dtos;
using GameStore.API.Entities;

namespace GameStore.API;

public static class GameMapping
{
    public static Game ToEntity(this CreateGame game, GameStoreContext dbContext)
    {
        var genre = dbContext.Genres.SingleOrDefault(QueryValue => QueryValue.Name == game.Genre);
        return new Game() //Stworzenie obiektu Game aby był kompatybilny z bazą danych
        {
            Name = game.Name,
            GenreId = genre!.Id,
            Price = game.Price,
            RealeaseDate = game.RealeaseDate
        };
    }

    public static Game ToEntity(this UpdateGame game, int id, GameStoreContext dbContext)
    {
        var genre = dbContext.Genres.SingleOrDefault(QueryValue => QueryValue.Name == game.Genre);
        return new Game() //Stworzenie obiektu Game aby był kompatybilny z bazą danych
        {
            Id = id,
            Name = game.Name,
            GenreId = genre!.Id,
            Price = game.Price,
            RealeaseDate = game.RealeaseDate
        };
    }

    public static GameDto ToDto(this Game game)
    {
        return new GameDto(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.RealeaseDate
            );
    }
}
