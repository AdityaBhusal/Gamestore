namespace Gamestore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public required string Genre { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public decimal Price { get; set; }

}
