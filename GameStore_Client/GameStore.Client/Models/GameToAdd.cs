namespace GameStore.Client.Models;
public class GameToAdd
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly RealeaseDate { get; set; }
}