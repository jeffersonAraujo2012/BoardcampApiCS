using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Customers.Interfaces;
using BoardcampApiCS.Resourses.Customers.Models;

namespace BoardcampApiCS.Resourses.Customers;

public class CustomersService
{
  private readonly ICustomersRepository _repository;

  public CustomersService(ICustomersRepository repository)
  {
    _repository = repository;
  }

  public async Task<Customer> CreateCustomer(Customer customerModel)
  {
    var existingCustomer = await _repository.GetByCpf(customerModel.Cpf);
    if (existingCustomer != null) throw new ConflictError("Conflict");

    return await _repository.CreateCustomer(customerModel);
  }

  public async Task<List<Customer>> GetCustomers()
  {
    return await _repository.GetCustomers();
  }

  public async Task<Customer> GetCustomerById(int id)
  {
    var customer = await _repository.GetCustomerById(id) ??
      throw new NotFoundError($"O cliente de id {id} não existe");

    return customer;
  }

  public async Task UpdateCustomer(int id, Customer customer)
  {
    if(await _repository.GetCustomerById(id) is null)
      throw new NotFoundError($"O cliente de id {id} não existe");

    var existingCustomerWithSameCpf = await _repository.GetByCpf(customer.Cpf);

    if (existingCustomerWithSameCpf?.Id != id && existingCustomerWithSameCpf != null) {
      Console.WriteLine(existingCustomerWithSameCpf.Id);
      throw new ConflictError("Conflito de CPF");
    }

    await _repository.UpdateCustomer(customer);
  }
}