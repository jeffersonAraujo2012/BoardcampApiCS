using AutoMapper;
using BoardcampApiCS.Resourses.Rentals.Dto;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.Extensions.Options;

namespace BoardcampApiCS.Resourses.Rentals;

public class RentalMapper : Profile
{
  public RentalMapper()
  {
    CreateMap<AddRentalInputModel, Rental>();
    CreateMap<Rental, RentalViewModel>()
      .ForMember(rvm => rvm.RentDate, options => options.MapFrom(r => r.RentDate.ToString("yyyy-MM-dd")))
      .ForMember(rvm => rvm.ReturnDate, options => options.MapFrom(r => r.ReturnDate != null ? r.ReturnDate.Value.ToString("yyyy-MM-dd") : null));
  }
}