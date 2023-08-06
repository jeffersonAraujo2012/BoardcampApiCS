using AutoMapper;
using BoardcampApiCS.Errors;
using BoardcampApiCS.Resourses.Customers;
using BoardcampApiCS.Resourses.Customers.Dto;
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

  public async Task<Rental> GetRentalByIdAsync(int id)
  {
    return await _repository.GetRentalByIdAsync(id) ??
      throw new NotFoundError($"O aluguel de id {id} não existe");
  }

  public async Task<List<Rental>> GetRentalsAsync()
  {
    return await _repository.GetRentalsAsync();
  }

  public async Task CreateRental(Rental rentalModel)
  {
    var game = await _gamesRepository.GetGameById(rentalModel.GameId) ??
      throw new BadRequestError($"O jogo de id {rentalModel.GameId} não existe.");

    var customer = await _customersRepository.GetCustomerById(rentalModel.CustomerId) ??
      throw new BadRequestError($"O cliente de id {rentalModel.CustomerId} não existe.");

    var openRentals = await _repository.GetRentalsByGameIdWhereReturnNullAsync(rentalModel.GameId);
    if (openRentals.Count >= game.StockTotal) throw new BadRequestError("Estoque insuficiente");

    rentalModel.OriginalPrice = rentalModel.DaysRented * (float)game.PricePerDay;

    await _repository.CreateRental(rentalModel);

    rentalModel.Customer = customer;
    rentalModel.Game = game;
  }

  public async Task ReturnRentalAsync(int id)
  {
    var rental = await _repository.GetRentalByIdAsync(id) ??
      throw new NotFoundError($"O aluguel de id {id} não existe.");

    if (rental.ReturnDate != null)
      throw new BadRequestError($"O aluguel de id {id} já foi finalizado.");
    
    int delay = (DateTime.Now - rental.RentDate).Days - rental.DaysRented;
    delay = delay < 0 ? 0 : delay;

    float delayFee = delay * (float)rental.Game.PricePerDay;

    await _repository.ReturnRentalAsync(id, delayFee);
  }
}