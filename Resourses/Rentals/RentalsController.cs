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

  [HttpPost]
  public async Task<ActionResult<RentalViewModel>> Post(AddRentalInputModel rentalModel) {
    var rental = _mapper.Map<Rental>(rentalModel);
    await _service.CreateRental(rental);
    var rentalView = _mapper.Map<RentalViewModel>(rental);
    return Created($"Rentals/{rental.Id}", rentalView);
  } 
}