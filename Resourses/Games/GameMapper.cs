using AutoMapper;
using BoardcampApiCS.Resourses.Games.DTO;
using BoardcampApiCS.Resourses.Games.Models;

namespace BoardcampApiCS.Resourses.Games;

public class GameMapper : Profile
{
  public GameMapper()
  {
    CreateMap<GameInputModel, Game>();
  }
}