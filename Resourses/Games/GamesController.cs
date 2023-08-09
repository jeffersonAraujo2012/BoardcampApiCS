using AutoMapper;
using BoardcampApiCS.Resourses.Games.DTO;
using BoardcampApiCS.Resourses.Games.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardcampApiCS.Resourses.Games;

[Route("[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly GamesService _gamesService;
  public GamesController(IMapper mapper, GamesService gamesService)
  {
    _mapper = mapper;
    _gamesService = gamesService;
  }

  [HttpGet]
  public async Task<ActionResult<List<GameViewModel>>> Get()
  {
    var games = await _gamesService.GetGames();
    var gamesViewModels = games.Select(game => _mapper.Map<GameViewModel>(game));
    return Ok(gamesViewModels);
  }

  [HttpPost]
  public async Task<ActionResult> Post(GameInputModel gameModel)
  {
    if (gameModel is null) return BadRequest("Você precisa enviar um game");

    try
    {
      var game = _mapper.Map<Game>(gameModel);
      await _gamesService.CreateGame(game);
      return Created($"games/{game.Id}", game);
    }
    catch (Exception ex)
    {
      if (ex.GetType().Name == "ConflictError")
      {
        Console.WriteLine(ex.GetType().Name);
        return Conflict(ex.Message);
      }
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}