using BoardcampApiCS.Resourses.Rentals.Models;

namespace BoardcampApiCS.Resourses.Rentals.Interfaces;

public interface IRentalsRepository
{
  public Task<Rental?> GetRentalByIdAsync(int id);

  public Task<List<Rental>> GetRentalsAsync();

  public Task CreateRental(Rental rental);

  public Task<List<Rental>> GetRentalsByGameIdWhereReturnNullAsync(int gameId);

  public Task ReturnRentalAsync(int id, float delayFee);

  public Task DeleteRentalAsync(Rental rental);
}