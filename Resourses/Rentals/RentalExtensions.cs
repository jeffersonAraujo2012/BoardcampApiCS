using BoardcampApiCS.Resourses.Rentals.Interfaces;
using BoardcampApiCS.Resourses.Rentals.Validators;
using FluentValidation;

namespace BoardcampApiCS.Resourses.Rentals;

public static class RentalExtensions
{
  public static void AddRentalServices(this IServiceCollection services)
  {
    services.AddScoped<RentalsService>();
    services.AddScoped<IRentalsRepository, RentalsRepository>();
    services.AddValidatorsFromAssemblyContaining<AddRentalValidator>();
    services.AddAutoMapper(typeof(RentalMapper));
  }
}