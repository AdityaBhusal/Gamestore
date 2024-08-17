using System;
using System.Runtime.CompilerServices;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient()
{
 private readonly List<GameSummary> games=
 [
    /*
    In this case, we are using a hardcoded list of games to simulate the data.
    */
    //cyberpunk 2077
    new(){
        Id=1,
        Name="Cyberpunk 2077",
        Genre="RPG",
        ReleaseDate=new DateOnly(2020,12,10),
        Price=59.99m
    },
    //the witcher 3
    new(){
        Id=2,
        Name="The Witcher 3",
        Genre="RPG",
        ReleaseDate=new DateOnly(2015,5,19),
        Price=29.99m
    },
    //doom eternal
    new(){
        Id=3,
        Name="Doom Eternal",
        Genre="FPS",
        ReleaseDate=new DateOnly(2020,3,20),
        Price=39.99m
    },
    //gta san andreas
    new(){
        Id=4,
        Name="GTA San Andreas",
        Genre="Action",
        ReleaseDate=new DateOnly(2004,6,7),
        Price=9.99m
    },
    //tomb raider aniversary
    new(){
        Id=5,
        Name="Tomb Raider Anniversary",
        Genre="Action",
        ReleaseDate= new DateOnly(2007,6,1),
        Price=19.99m
     }
    ];

    private readonly Genre[] genres = new GenresClient().getGenres();
    public GameSummary[] GetGames()=> [.. games];
    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        if (genre is null)
        {
            throw new ArgumentException("Invalid genre id");
        }
        else
        {
            var GameSummary = new GameSummary
            {
                Id = games.Count + 1,
                Name = game.Name,

                /*
                Genre=game.GenreId,
                -------------------
                ^^^^^^^^^^^^^^^^^^^
                -> this won't work because we need to convert the genre id to genre name
                */
                Genre = genre.Name,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price
            };

            games.Add(GameSummary);
        }

    }
    public GameDetails GetGamesByInt(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
          genre.Name,
          game.Genre,
          StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            ReleaseDate = game.ReleaseDate,
            Price = game.Price
        };

    }
    public void UpdateGame(GameDetails updatedGame){
        var genre=GetGenreById(updatedGame.GenreId);
        GameSummary existingGame=GetGameSummaryById(updatedGame.Id);

        existingGame.Name=updatedGame.Name;
        existingGame.Genre=genre.Name;
        existingGame.ReleaseDate=updatedGame.ReleaseDate;
        existingGame.Price=updatedGame.Price;
    }
    public void DeleteGame(int id){
        var game =GetGameSummaryById(id);
        games.Remove(game);
    }
    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.FirstOrDefault(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game, "Game not found");
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return  genres.Single(g => g.Id == int.Parse(id));
    }

}

    
