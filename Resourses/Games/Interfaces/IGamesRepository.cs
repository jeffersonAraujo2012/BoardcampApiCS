using BoardcampApiCS.Resourses.Games.Models;

namespace BoardcampApiCS.Resourses.Games.Interfaces;

public interface IGamesRepository {
  public Task CreateGame(Game game);

  public Task<Game?> GetGameByName(string gameName);

  public Task<List<Game>> GetGames();

  public Task<Game?> GetGameById(int id);
}