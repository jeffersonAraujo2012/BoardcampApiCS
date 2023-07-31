using BoardcampApiCS.Contexts;
using BoardcampApiCS.Resourses.Games.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Resourses.Games;

public class GamesRepository
{
  private readonly AppDbContext _context;
  public GamesRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task CreateGame(Game game)
  {
    await _context.Games.AddAsync(game);
    await _context.SaveChangesAsync();
  }

  public async Task<Game?> GetGameByName(string gameName)
  {
    return await _context.Games
      .FirstOrDefaultAsync(game => game.Name.Equals(gameName));
  }
}