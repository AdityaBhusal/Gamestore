namespace Gamestore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    public required string  Name { get; set; }
    public string? GenreId { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public decimal Price { get; set; }

}
