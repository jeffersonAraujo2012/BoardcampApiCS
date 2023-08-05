using BoardcampApiCS.Contexts;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Resourses.Rentals;

public class RentalsRepository
{
  private readonly AppDbContext _context;
  public RentalsRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task CreateRental(Rental rental) {
    await _context.Rentals.AddAsync(rental);
    await _context.SaveChangesAsync();
  }

  public async Task<List<Rental>> GetRentalsByGameIdWhereReturnNullAsync(int gameId) {
    return await _context.Rentals
      .Where(rental => rental.GameId == gameId && rental.ReturnDate == null)
      .ToListAsync();
  }
}