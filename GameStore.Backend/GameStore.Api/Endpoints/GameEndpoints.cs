using System.Reflection.Metadata.Ecma335;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";
    private static readonly List<GameSummaryDto> games =
    [
        new(1, "Super Mario Bros", "Platform", 59.99m, new DateOnly(1985, 9, 13)),
        new(2, "The Legend of Zelda", "Action-Adventure", 49.99m, new DateOnly(1986, 2, 21)),
        new(3, "Minecraft", "Sandbox", 29.99m, new DateOnly(2011, 11, 18))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //GET /games
        group.MapGet("", () => games);

        //Get /games/{id}
        group
            .MapGet(
                "/{id}",
                (int id, GameStoreContext dbContext) =>
                {
                    Game? game = dbContext.Games.Find(id);

                    return game is not null ? Results.Ok(game.ToGameDetailsDto()) : Results.NotFound();
                }
            )
            .WithName(GetGameEndPointName);

        //post /games
        group.MapPost(
            "/",
            (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();
                // game.Genre = dbContext.Genre.Find(newGame.GenreId);

                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(
                    GetGameEndPointName,
                    new { id = game.Id },
                    game.ToGameDetailsDto()
                );
            }
        );

        //put /games/{id}
        group.MapPut(
            "/{id}",
            (int id, UpdateGameDto updatedGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                games[index] = new GameSummaryDto(
                    id,
                    updatedGame.Name,
                    updatedGame.Genre,
                    updatedGame.Price,
                    updatedGame.ReleaseDate
                );

                return Results.NoContent();
            }
        );

        //delete /game/{id}
        group.MapDelete(
            "/{id}",
            (int id) =>
            {
                var game = games.RemoveAll(g => g.Id == id);

                //If the game was deleted, return 204 No Content
                //If the game was not found, return 404 Not Found
                return game > 0 ? Results.NoContent() : Results.NotFound();
            }
        );

        return group;
    }
}
