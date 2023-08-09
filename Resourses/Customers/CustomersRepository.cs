using BoardcampApiCS.Contexts;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Customers.Interfaces;
using BoardcampApiCS.Resourses.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Resourses.Customers;

public class CustomersRepository : ICustomersRepository
{
  private readonly AppDbContext _context;
  public CustomersRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Customer?> GetByCpf(string cpf)
  {
    return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cpf);
  }

  public async Task<Customer> CreateCustomer(Customer customerModel)
  {
    await _context.AddAsync(customerModel);
    await _context.SaveChangesAsync();
    return await _context.Customers.FirstAsync(c => c.Cpf == customerModel.Cpf);
  }

  public async Task<List<Customer>> GetCustomers()
  {
    return await _context.Customers.AsNoTracking().ToListAsync();
  }

  public async Task<Customer?> GetCustomerById(int id)
  {
    return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
  }

  public async Task UpdateCustomer(Customer customer)
  {
    _context.Entry(customer).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}