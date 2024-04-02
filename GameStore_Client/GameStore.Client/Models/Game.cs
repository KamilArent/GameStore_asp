using System.ComponentModel.DataAnnotations;

namespace GameStore.Client.Models;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)] //Maksymalna długość nazwy gry
    public required string Name { get; set; }

    [Required]
    [StringLength(20)] //Maksymalna długość nazwy kategori
    public required string Genre { get; set; }
    public DateOnly RealeaseDate { get; set; }

    [Range(0, 200)]
    public decimal Price { get; set; }
}