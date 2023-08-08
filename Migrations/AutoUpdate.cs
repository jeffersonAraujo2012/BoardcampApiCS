using BoardcampApiCS.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Migrations.AutoUpdate;

public static class AutoUpdate
{
  public static void Run(IApplicationBuilder app)
  {
    app.ApplicationServices.GetService<AppDbContext>()?.Database.Migrate();
  }
}