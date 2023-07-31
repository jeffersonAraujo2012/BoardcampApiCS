using BoardcampApiCS.Resourses.Games.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Contexts;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Game> Games { get; set; }
}