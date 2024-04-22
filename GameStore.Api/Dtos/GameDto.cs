namespace GameStore.Api.Dtos;

/**
 * Object type DTO (Data transfer object), this object encapsulates data
 * so that they can be easily transmited across different layers of our 
 * application, so for this DTO's, Records are the perfect fit because
 * they are inmmutable meaning that once the properties are set they can't
 * be changed and like DTO's Records can carry data without the needing of
 * any kind of modification.
 */
public record class GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
