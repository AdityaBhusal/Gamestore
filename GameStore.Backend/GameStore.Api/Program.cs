using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndPointName = "GetGame";
List<GameDto> games=[
    new(
        1,
        "Super Mario Bros",
        "Platform",
        59.99m,
        new DateOnly(1985, 9, 13)
    ),
    new(
        2,
        "The Legend of Zelda",
        "Action-Adventure",
        49.99m,
        new DateOnly(1986, 2, 21)
    ),
    new(
        3,
        "Minecraft",
        "Sandbox",
        29.99m,
        new DateOnly(2011, 11, 18)
    )
];

//GET /games
app.MapGet("games", () => games);

//Get /games/{id}
app.MapGet("games/{id}",
 (int id)=>
{
    GameDto? game =  games.Find(g=>g.Id==id);

    return game is not null ? Results.Ok(game): Results.NotFound();

})
.WithName(GetGameEndPointName);

 //post /games
 app.MapPost("games", (CreateGameDto newGame) =>
    {
        GameDto game = new(
            games.Count + 1,
            newGame.Name,
            newGame.Genre,
            newGame.Price,
            newGame.ReleaseDate);

        games.Add(game);

        return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.Id}, game);
    });

//put /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id );

    games[index] = new GameDto
    (
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );

    return Results.NoContent();
});

//delete /game/{id}
app.MapDelete("games/{id}",(int id)=>
{
    games.RemoveAll(game=>game.Id == id);
    return Results.NoContent;
}
);
app.Run();
