using System.ComponentModel.DataAnnotations;

namespace Gamestore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string  Name { get; set; }
    [Required]
    public string? GenreId { get; set; }
    [Range(1,100)]
    public DateOnly ReleaseDate { get; set; }
    public decimal Price { get; set; }

}
