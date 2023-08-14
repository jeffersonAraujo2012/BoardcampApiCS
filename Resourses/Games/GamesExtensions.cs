using BoardcampApiCS.Resourses.Games.Interfaces;

namespace BoardcampApiCS.Resourses.Games;

public static class GamesExtensions {
  public static void AddGameServices(this IServiceCollection services) {
    services.AddScoped<GamesService>();
    services.AddScoped<IGamesRepository, GamesRepository>();
  }
}