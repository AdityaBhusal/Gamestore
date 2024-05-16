using System;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient
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
/*
    we used list of GameSummary objects to store the games data.
    list is a collection that allows us to store multiple items of the same type.
    In this case, we are storing GameSummary objects.

    syntax of list is:
    List<T> where T is the type of the items stored in the list.

    In this case, we are storing GameSummary objects, so the type of the list is List<GameSummary>.
    We used the new keyword to create a new instance of the List<GameSummary> class.
    We used the collection initializer syntax to add the GameSummary objects to the list.
    The collection initializer syntax allows us to add multiple items to a collection in a single statement.
    
    // Collection initializer syntax
    new List<GameSummary>
    {
        // Add GameSummary objects here
    };
*/
    private readonly Genre[] genres = new GenresClient().getGenres();

    public Genre[] Genres1 => genres;

    //we used array of Genre objects to store the genres data.
    //the genres data is retrieved from the GenresClient class using the GetGenres method.
    //the GetGenres method returns an array of Genre objects which is defined in the GenresClient class.
    //which is defined in the GenresClient class.

    public GameSummary[] GetGames()=> [.. games];

    public void AddGame(GameDetails game)
    {
        //we receive game details not game summary from edit.razor
        //we need to convert game details to game summary
        //we need to generate a new id for the game
        //we need to add the new game to the list of games withthe help of edit.razor page
        //edit.razor page will call this method to add the new game to the list of games


        //the syntax for var is:
        //var variableName = value;
        //we used the var keyword to declare a variable without specifying the type explicitly.
        //The type of the variable is inferred from the value assigned to it.
        //In this case, the type of the variable is GameSummary because the value assigned to it is a GameSummary object.
        //We used the new keyword to create a new instance of the GameSummary class.
        //We used the object initializer syntax to set the properties of the GameSummary object.
        //The object initializer syntax allows us to set the properties of an object in a single statement.

        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        
        
        //we used the ArgumentExeption.ThrowIfNullOrWhiteSpace method to check if the genre id is null or whitespace.
        //The ThrowIfNullOrWhiteSpace method throws an ArgumentException if the genre id is null or whitespace.
        //The ArgumentException is a built-in exception class that represents an exception that is thrown when one of the arguments provided to a method is not valid.
        //The ArgumentException class has a constructor that takes a message as an argument.
        //The message is a string that describes the error that occurred.
        //In this case, the message is "GenreId cannot be null or whitespace.".
        //The ArgumentException class has a property called ParamName that stores the name of the parameter that caused the exception.
        //In this case, the parameter name is "game.GenreId".
        //The ArgumentException class has a property called Message that stores the error message.
        //In this case, the error message is "GenreId cannot be null or whitespace.".

        
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        //return a genre whose id is 

        //we used the Single method to find the genre with the specified id.
        //The Single method returns the first element of the sequence that satisfies the specified condition.
        //In this case, the condition is genre => genre.Id == int.Parse(game.GenreId).
        //The condition checks if the id of the genre is equal to the id of the game genre.
        //The int.Parse method is used to convert the genre id from a string to an integer.
        //The genre id is stored as a string in the game object, so we need to convert it to an integer to compare it with the genre id.

        var GameSummary = new GameSummary{
            Id=games.Count+1,
            Name=game.Name,

            /*
            Genre=game.GenreId,
            -------------------
            ^^^^^^^^^^^^^^^^^^^
            -> this won't work because we need to convert the genre id to genre name
            */
            Genre=genre.Name,
            ReleaseDate=game.ReleaseDate,
            Price=game.Price
        };

        games.Add(GameSummary);
        //we used the Add method to add the new game to the list of games.
        //The Add method adds an item to the end of the list.
        //In this case, we added the GameSummary object to the games list.
        //The GameSummary object contains the details of the new game that was created.
        //The new game is added to the end of the list of games.

    }

        

    }

    
