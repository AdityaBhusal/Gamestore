﻿using System.Reflection.Metadata.Ecma335;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";
    private static readonly List<GameDto> games =
    [
        new(1, "Super Mario Bros", "Platform", 59.99m, new DateOnly(1985, 9, 13)),
        new(2, "The Legend of Zelda", "Action-Adventure", 49.99m, new DateOnly(1986, 2, 21)),
        new(3, "Minecraft", "Sandbox", 29.99m, new DateOnly(2011, 11, 18))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        //GET /games
        group.MapGet("", () => games);

        //Get /games/{id}
        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    GameDto? game = games.Find(g => g.Id == id);

                    return game is not null ? Results.Ok(game) : Results.NotFound();
                }
            )
            .WithName(GetGameEndPointName);

        //post /games
        group.MapPost(
            "",
            (CreateGameDto newGame) =>
            {
                GameDto game =
                    new(
                        games.Count + 1,
                        newGame.Name,
                        newGame.Genre,
                        newGame.Price,
                        newGame.ReleaseDate
                    );

                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
            }
        ).WithParameterValidation();

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

                games[index] = new GameDto(
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
        group.MapDelete("/{id}", (int id) =>
        {
            var game = games.RemoveAll(g => g.Id == id);


            //If the game was deleted, return 204 No Content
            //If the game was not found, return 404 Not Found
            return game > 0 ? Results.NoContent() : Results.NotFound();
        });

        return group;
    }
}