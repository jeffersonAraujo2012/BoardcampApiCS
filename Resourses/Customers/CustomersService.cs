using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Customers.Models;

namespace BoardcampApiCS.Resourses.Customers;

public class CustomersService
{
  private readonly CustomersRepository _repository;

  public CustomersService(CustomersRepository repository)
  {
    _repository = repository;
  }

  public async Task<Customer> CreateCustomer(Customer customerModel)
  {
    var existingCustomer = await _repository.GetByCpf(customerModel.Cpf);
    if (existingCustomer != null) throw new ConflictError("Conflict");

    return await _repository.CreateCustomer(customerModel);
  }
}