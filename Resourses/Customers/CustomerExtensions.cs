using BoardcampApiCS.Resourses.Games;

namespace BoardcampApiCS.Resourses.Customers;

public static class CustomerExtensions {
  public static void ExtendsServices(IServiceCollection services) {
    services.AddScoped<CustomersService>();
    services.AddScoped<CustomersRepository>();
    services.AddAutoMapper(typeof(CustomerMapper));
  }
}