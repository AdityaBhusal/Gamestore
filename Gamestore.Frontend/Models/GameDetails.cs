using System.ComponentModel.DataAnnotations;

namespace Gamestore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string  Name { get; set; }
    [Required(ErrorMessage = "The Genre field is required.")]
    public string? GenreId { get; set; }
    public DateOnly ReleaseDate { get; set; }
    [Range(1,100)]
    public decimal Price { get; set; }

}
