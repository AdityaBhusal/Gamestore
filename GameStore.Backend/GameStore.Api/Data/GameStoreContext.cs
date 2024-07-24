using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext (DbContextOptions<GameStoreContext> options)
 : DbContext(options)
{
    public DbSet<Game> Games { get; set; };
}
