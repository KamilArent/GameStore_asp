

namespace GameStore.API.dtos;

public record class GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly RealeaseDate
);