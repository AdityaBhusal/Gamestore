using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient
{
 private readonly List<GameSummary> games=
 [
    /*
    we created games client to simulate a real API client that fetches data from a remote server.
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

    }