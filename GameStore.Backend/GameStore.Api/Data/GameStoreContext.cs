using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genre => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Genre>()
            .HasData(
                new { id = 1, Name = "Action" },
                new { id = 2, Name = "Adventure" },
                new { id = 3, Name = "RPG" },
                new { id = 4, Name = "Simulation" },
                new { id = 5, Name = "Strategy" },
                new { id = 6, Name = "Sports" },
                new { id = 7, Name = "Puzzle" },
                new { id = 8, Name = "Horror" },
                new { id = 9, Name = "Survival" },
                new { id = 10, Name = "MMO" },
                new { id = 11, Name = "Racing" },
                new { id = 12, Name = "Fighting" },
                new { id = 13, Name = "Shooter" },
                new { id = 14, Name = "Platformer" },
                new { id = 15, Name = "Sandbox" },
                new { id = 16, Name = "Open World" },
                new { id = 17, Name = "Metroidvania" },
                new { id = 18, Name = "Stealth" },
                new { id = 19, Name = "Battle Royale" },
                new { id = 20, Name = "Roguelike" },
                new { id = 21, Name = "Rhythm" },
                new { id = 22, Name = "Music" },
                new { id = 23, Name = "Educational" },
                new { id = 24, Name = "Casual" },
                new { id = 25, Name = "Idle" },
                new { id = 26, Name = "Clicker" },
                new { id = 27, Name = "Incremental" },
                new { id = 28, Name = "Text-Based" },
                new { id = 29, Name = "Visual Novel" },
                new { id = 30, Name = "Dating Sim" },
                new { id = 31, Name = "Life Sim" },
                new { id = 32, Name = "Tycoon" },
                new { id = 33, Name = "City Builder" },
                new { id = 34, Name = "Management" },
                new { id = 35, Name = "Real-Time Strategy" },
                new { id = 36, Name = "Turn-Based Strategy" },
                new { id = 37, Name = "Tower Defense" },
                new { id = 38, Name = "4X" },
                new { id = 39, Name = "Grand Strategy" },
                new { id = 40, Name = "MOBA" },
                new { id = 41, Name = "Card Game" },
                new { id = 42, Name = "Board Game" },
                new { id = 43, Name = "Party Game" },
                new { id = 44, Name = "Trivia" },
                new { id = 45, Name = "Poker" },
                new { id = 46, Name = "Chess" },
                new { id = 47, Name = "Checkers" },
                new { id = 48, Name = "Go" },
                new { id = 49, Name = "Mahjong" },
                new { id = 50, Name = "Solitaire" },
                new { id = 51, Name = "Casino" },
                new { id = 52, Name = "Arcade" },
                new { id = 53, Name = "Pinball" },
                new { id = 54, Name = "Beat 'em Up" },
                new { id = 55, Name = "Hack and Slash" }
            );
    }
}
