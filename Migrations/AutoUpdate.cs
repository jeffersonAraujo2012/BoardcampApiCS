using BoardcampApiCS.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Migrations.AutoUpdate;

public static class AutoUpdate
{
  public static void Run(IApplicationBuilder app)
  {
    using var scope = app.ApplicationServices.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
  }
}