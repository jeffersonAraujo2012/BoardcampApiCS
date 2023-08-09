using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Games.Models;
using BoardcampApiCS.Resourses.Games.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BoardcampApiCS.Resourses.Games;

public class GamesService
{
  private readonly IGamesRepository _gamesRepository;
  public GamesService(IGamesRepository gamesRepository)
  {
    _gamesRepository = gamesRepository;
  }

  public async Task<List<Game>> GetGames()
  {
    return await _gamesRepository.GetGames();
  }

  public async Task CreateGame(Game game)
  {
    var existingGame = await _gamesRepository.GetGameByName(game.Name);
    if (existingGame != null)
    {
      throw new ConflictError("Já existe um jogo com o nome enviado. Tente outro nome.");
    }

    await _gamesRepository.CreateGame(game);
  }
}