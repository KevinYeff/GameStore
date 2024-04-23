using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

/**
 * GamesEndpoints - Static class that contains an extension method which is
 * going to be static
 */
public static class GamesEndpoints
{
    // Const to avoid hardcoding the name of route
    const string GetGameEndPoint = "GetGame";
    
    /** 
     * This represents the collection of objects of type GameDto
     * (List of records)
     */
    private readonly static List<GameDto> games = 
        // bunch of prefered games
        [
        new (
            1,
            "Street Fighter II",
            "Fighting",
            // the M especifies that the number is a float
            19.99M,
            new DateOnly(1992, 7, 15)),
        new (
            2,
            "Final Fantasy XIV",
            "Roleplaying",
            59.99M,
            new DateOnly(2010, 9, 30)),
        new (
            3,
            "FIFA 23",
            "Sports",
            69.99M,
            new DateOnly(2022, 9, 27))
    ];

    /**
     * MapGamesEndpoints - Extension method that encapsulates the configuration
     * of game-related routes and groups all the endpoint definitions related
     * to the application, remember that the endpoints remains consistant
     * throughout the application's execution 
     */
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                       .WithParameterValidation();
        
        // GET /games - Returns the list of objects of type Record
        group.MapGet("/", () => games);

        // GET /games/1 - Returns the object based on id from the list
        group.MapGet("/{id}", (int id) => 
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        // gives a name to he endpoint
        .WithName(GetGameEndPoint);

        /** 
         * POST /games - Creates a new resource, expects to receive an object
         * of the type of our DTO (CreateGameDto), adds to the list.
         * Tells the result of the operation to the client, including
         * a location to the resource that just got created, so the client
         * knows how to find the resource easily.
         *
         * Return: A helper method Results.CreatedAtRoute with code 201 as
         * and the location as a response.
         */

        group.MapPost("/", (CreateGameDto newGame) => 
        {
            // converts the CreateGameDto to the normal GameDto
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
        });

        /**
         * PUT /games - Updates a existing resource based on id by replacing the
         * resource with an object of type UpdateGameDto
         *
         * Returns: A helper method Result.NoContent with 204 code in any case
         */

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1) {
                return Results.NotFound();
            };

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
                );

                return Results.NoContent();
        });

        // DELETE /games/1 - Deletes a resource based on Id
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
        return group;
    }
}
