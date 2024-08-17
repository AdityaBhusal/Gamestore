using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
//when addsqllite is called, gamestorecontext is injected into the services collection as a scoped service
//scoped service means that it is created once per request and disposed of when the request is done
//this is the default lifetime of a service

var app = builder.Build();
app.MapGamesEndpoints();
app.MapGenresEndpoints();
await app.MigrateDbAsync();

app.Run();
