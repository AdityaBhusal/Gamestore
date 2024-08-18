using System.Reflection.Metadata.Ecma335;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //GET /games
        group.MapGet(
            "",
            async (GameStoreContext dbContext) =>{
                // await Task.Delay(3000);
                return await dbContext
                    .Games.Include(game => game.Genre)
                    .Select(game => game.ToGameSummaryDto())
                    .AsNoTracking()
                    .ToListAsync();
            });

        //Get /games/{id}
        group
            .MapGet(
                "/{id}",
                async (int id, GameStoreContext dbContext) =>
                {
                    Game? game = await dbContext.Games.FindAsync(id);

                    return game is not null
                        ? Results.Ok(game.ToGameDetailsDto())
                        : Results.NotFound();
                }
            )
            .WithName(GetGameEndPointName);

        //post /games
        group.MapPost(
            "/",
            async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();
                // game.Genre = dbContext.Genre.Find(newGame.GenreId);

                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();

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
            async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );

        //delete /game/{id}
        group.MapDelete(
            "/{id}",
            async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
                //If the game was deleted, return 204 No Content
                //If the game was not found, return 404 Not Found
                return Results.NoContent();
            }
        );

        return group;
    }
}
