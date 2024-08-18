using System;
using System.Runtime.CompilerServices;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("games", game);
    public async Task<GameDetails> GetGameAsync (int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? 
        throw new Exception("The game of given id is not found/ is currently unavailable.");
    public async Task UpdateGameAsync(GameDetails updatedGame)
        =>await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");
}