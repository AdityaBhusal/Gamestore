using Gamestore.Frontend.Clients;
using Gamestore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// comment
// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var gameStoreApiUrl = "http://localhost:5057";

// Add http client
// Register the GamesClient with the DI container
// so that it can be injected into components
builder.Services.AddHttpClient<GamesClient>(client =>
    client.BaseAddress = new Uri(gameStoreApiUrl)
);

builder.Services.AddHttpClient<GenresClient>(client =>
    client.BaseAddress = new Uri(gameStoreApiUrl)
);

builder.Services.AddSingleton<GamesClient>();
builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
