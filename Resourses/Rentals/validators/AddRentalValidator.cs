using BoardcampApiCS.Resourses.Rentals.Dto;
using FluentValidation;

namespace BoardcampApiCS.Resourses.Rentals.Validators;

public class AddRentalValidator : AbstractValidator<AddRentalInputModel>
{
  public AddRentalValidator()
  {
    RuleFor(n => n.GameId)
      .NotEmpty()
      .Must(gameId => gameId >= 0)
      .WithMessage("O gameId deve ser igual ou maior que 1");
    
    RuleFor(n => n.CustomerId)
      .NotEmpty()
      .Must(customerId => customerId >= 0)
      .WithMessage("O customerId deve ser igual ou maior que 1");
    
    RuleFor(n => n.DaysRented)
      .NotEmpty()
      .Must(daysRented => daysRented >= 0)
      .WithMessage("O daysRented deve ser igual ou maior que 1");
  }
}