using System.Data;
using BoardcampApiCS.Resourses.Customers.Dto;
using FluentValidation;

namespace BoardcampApiCS.Resourses.Customers.Validators;

public class AddCustomerValidator : AbstractValidator<CustomerInputModel>
{
  public AddCustomerValidator()
  {
    RuleFor(n => n.Cpf)
      .Matches(@"^\d{11}$")
      .WithMessage("O CPF deve ser um conjunto de 11 dígitos de 0 à 9 sem separadores (ponto, traço)");
    
    RuleFor(n => n.Phone)
      .Matches(@"^\d{10,11}$")
      .WithMessage("O telefone deve ter de 10 a 11 dígitos de 0 à 9 sem separadores (ponto, traço)");
  }
}