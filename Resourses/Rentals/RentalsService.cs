using AutoMapper;
using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Customers;
using BoardcampApiCS.Resourses.Games;
using BoardcampApiCS.Resourses.Rentals.Dto;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BoardcampApiCS.Resourses.Rentals;

public class RentalsService
{
  private readonly IMapper _mapper;
  private readonly RentalsRepository _repository;
  private readonly GamesRepository _gamesRepository;
  private readonly CustomersRepository _customersRepository;
  public RentalsService(RentalsRepository repository, GamesRepository gamesRepository, CustomersRepository customersRepository, IMapper mapper)
  {
    _mapper = mapper;
    _repository = repository;
    _gamesRepository = gamesRepository;
    _customersRepository = customersRepository;
  }
  public async Task CreateRental(Rental rentalModel)
  {
    var game = await _gamesRepository.GetGameById(rentalModel.GameId) ??
      throw new BadRequestError($"O jogo de id {rentalModel.GameId} não existe.");

    _ = await _customersRepository.GetCustomerById(rentalModel.CustomerId) ??
      throw new BadRequestError($"O cliente de id {rentalModel.CustomerId} não existe.");

    var openRentals = await _repository.GetRentalsByGameIdWhereReturnNullAsync(rentalModel.GameId);
    if (openRentals.Count >= game.StockTotal) throw new BadRequestError("Estoque insuficiente");

    rentalModel.OriginalPrice = rentalModel.DaysRented * (float) game.PricePerDay;

    await _repository.CreateRental(rentalModel);
  }


}