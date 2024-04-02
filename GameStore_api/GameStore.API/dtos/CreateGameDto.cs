using System.ComponentModel.DataAnnotations;

namespace GameStore.API.dtos;

public record class CreateGame(
    [Required] string Name,
    [Required] string Genre,
    [Range(0, 100)] decimal Price,
    DateOnly RealeaseDate
);