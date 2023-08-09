using BoardcampApiCS.Resourses.Customers.Models;

namespace BoardcampApiCS.Resourses.Customers.Interfaces;

public interface ICustomersRepository
{
  public Task<Customer?> GetByCpf(string cpf);
  public Task<Customer?> GetCustomerById(int id);
  public Task<List<Customer>> GetCustomers();
  public Task<Customer> CreateCustomer(Customer customerModel);
  public Task UpdateCustomer(Customer customer);
}