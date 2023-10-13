using System.ComponentModel.DataAnnotations;

namespace GameStore.Api;
public class Game
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Genre { get; set; }
    [Required]
    [Range(1, 100)]
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    [Url]
    [StringLength(100)]
    public required string ImageUri { get; set; }
}