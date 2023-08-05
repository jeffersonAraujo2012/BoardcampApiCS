using AutoMapper;
using BoardcampApiCS.Resourses.Rentals.Dto;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardcampApiCS.Resourses.Rentals;

[Route("[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
  private readonly RentalsService _service;
  private readonly IMapper _mapper;
  public RentalsController(RentalsService service, IMapper mapper)
  {
    _service = service;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<List<RentalViewModel>>> Get()
  {
    var rentals = await _service.GetRentalsAsync();
    var rentalsViews = rentals.Select(r => _mapper.Map<RentalViewModel>(r));
    return Ok(rentalsViews);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<RentalViewModel>> GetById(int id)
  {
    var rental = await _service.GetRentalByIdAsync(id);
    return Ok(_mapper.Map<RentalViewModel>(rental));
  }

  [HttpPost]
  public async Task<ActionResult<RentalViewModel>> Post(AddRentalInputModel rentalModel)
  {
    var rental = _mapper.Map<Rental>(rentalModel);
    await _service.CreateRental(rental);
    var rentalView = _mapper.Map<RentalViewModel>(rental);
    return Created($"Rentals/{rental.Id}", rentalView);
  }
}