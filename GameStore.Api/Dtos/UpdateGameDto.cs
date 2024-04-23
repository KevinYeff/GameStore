using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

/**
 * Defines the representation of the object (resource) that our api will
 * update, note that the clients will provide the id for the resource in
 * this PUT operation.
 */
public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
