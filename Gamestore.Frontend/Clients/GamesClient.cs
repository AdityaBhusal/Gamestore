﻿using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient
{
 private readonly List<GameSummary> games=
 [
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

    public GameSummary[] GetGames()=>games.ToArray();

    }