using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Customers.Models;
using Microsoft.AspNetCore.Mvc;

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