using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
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

app.MapGet("games", () => games);
app.MapGet("/", () => "Hello World!");

app.Run();
