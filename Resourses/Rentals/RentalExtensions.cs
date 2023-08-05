using BoardcampApiCS.Resourses.Rentals.Validators;
using FluentValidation;

namespace BoardcampApiCS.Resourses.Rentals;

public static class RentalExtensions 
{
  public static void AddExtensions(IServiceCollection services) {
    services.AddScoped<RentalsService>();
    services.AddScoped<RentalsRepository>();
    services.AddValidatorsFromAssemblyContaining<AddRentalValidator>();
    services.AddAutoMapper(typeof(RentalMapper));
  }
}