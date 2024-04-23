using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;
/**
 * Defines the representation of the objects (resources) that our api will
 * receive, note that we are not going to require an id for from the clients
 * for the resource.
 */
public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
