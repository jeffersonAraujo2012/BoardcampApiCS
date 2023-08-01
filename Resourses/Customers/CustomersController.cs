using AutoMapper;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Customers.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BoardcampApiCS.Resourses.Customers;

[Route("[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly CustomersService _service;
  public CustomersController(IMapper mapper, CustomersService service)
  {
    _mapper = mapper;
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<CustomerViewModel>>> Get() {
    var customers = await _service.GetCustomers();
    var customersView = customers.Select(c => _mapper.Map<CustomerViewModel>(c));
    return Ok(customersView);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<CustomerViewModel>> GetById(int id) {
    var customer = await _service.GetCustomerById(id);
    return Ok(_mapper.Map<CustomerViewModel>(customer));
  }

  [HttpPost]
  public async Task<ActionResult<CustomerViewModel>> Post(CustomerInputModel customerModel)
  {
    var customer = _mapper.Map<Customer>(customerModel);
    await _service.CreateCustomer(customer);
    var customerView = _mapper.Map<CustomerViewModel>(customer);
    return Created($"Customers/{customerView.Id}", customerView);
  }
}