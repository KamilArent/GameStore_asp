using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Tower Defense" },
            new { Id = 2, Name = "Fighting" },
            new { Id = 3, Name = "Racing" },
            new { Id = 4, Name = "Kids" }
        );

        modelBuilder.Entity<Game>().HasData(
            new { Id = 1, Name = "BTD6", GenreId = 1, Price = 5.99M, RealeaseDate = new DateOnly(2018, 9, 20) },
            new { Id = 2, Name = "Minecraft", GenreId = 4, Price = 15.99M, RealeaseDate = new DateOnly(2013, 10, 13) }
        );
    }
}
