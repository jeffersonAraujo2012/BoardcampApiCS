using BoardcampApiCS.Resourses.Games.Interfaces;

namespace BoardcampApiCS.Resourses.Games;

public static class GamesExtends {
  public static void ExtendsServices(IServiceCollection services) {
    services.AddScoped<GamesService>();
    services.AddScoped<IGamesRepository, GamesRepository>();
  }
}