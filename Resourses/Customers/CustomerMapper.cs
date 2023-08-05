using AutoMapper;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Customers.Models;

namespace BoardcampApiCS.Resourses.Customers;

public class CustomerMapper : Profile
{
  public CustomerMapper()
  {
    CreateMap<CustomerInputModel, Customer>();
    CreateMap<Customer, CustomerViewModel>()
      .ForMember(cvm => cvm.Birthday, options => options.MapFrom(c => c.Birthday.ToString("yyyy-MM-dd")));
    CreateMap<Customer, CustomerSimpleViewModel>();
  }
}