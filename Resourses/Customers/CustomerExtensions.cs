using BoardcampApiCS.Resourses.Customers.Interfaces;

namespace BoardcampApiCS.Resourses.Customers;

public static class CustomerExtensions {
  public static void AddCustomerServices(this IServiceCollection services) {
    services.AddScoped<CustomersService>();
    services.AddScoped<ICustomersRepository, CustomersRepository>();
    services.AddAutoMapper(typeof(CustomerMapper));
  }
}