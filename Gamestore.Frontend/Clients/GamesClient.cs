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
        var GameSummary = new GameSummary
    }

    }
    }