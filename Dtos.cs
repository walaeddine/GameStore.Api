using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto(
    [Required][MaxLength(50)] string Name,
    [Required][MaxLength(50)] string Genre,
    [Required][Range(1, 100)] decimal Price,
    DateTime ReleaseDate,
    [Required][MaxLength(100)] string ImageUri
);
public record UpdateGameDto(
    [Required][MaxLength(50)] string Name,
    [Required][MaxLength(50)] string Genre,
    [Required][Range(1, 100)] decimal Price,
    DateTime ReleaseDate,
    [Required][MaxLength(100)] string ImageUri
);