using BoardcampApiCS.Resourses.Customers.Models;
using BoardcampApiCS.Resourses.Games.Models;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Contexts;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Game> Games { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Rental> Rentals { get; set; }
}