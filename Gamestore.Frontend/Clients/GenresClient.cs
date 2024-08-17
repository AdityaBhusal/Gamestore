using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GenresClient()
{
    private readonly Genre[] genres=[
        new(){
            Id=1,
            Name="RPG"
        },
        new(){
            Id=2,
            Name="FPS"
        },
        new(){
            Id=3,
            Name="Action"
        },
        new(){
            Id=4,
            Name="Adventure"
        },
        new(){
            Id=5,
            Name="Simulation"
        },
        new(){
            Id=6,
            Name="Strategy"
        },
        new(){
            Id=7,
            Name="Sports"
        },
        new(){
            Id=8,
            Name="Horror"
        },
        new(){
            Id=9,
            Name="Puzzle"
        },
        new(){
            Id=10,
            Name="Racing"
        },
        new(){
            Id=11,
            Name="Fighting"
        },
        new(){
            Id=12,
            Name="Platformer"
        }
    ];

    public Genre[] getGenres() => genres;
}
