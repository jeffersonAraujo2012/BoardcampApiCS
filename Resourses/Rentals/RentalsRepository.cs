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

  public async Task<Rental?> GetRentalByIdAsync(int id)
  {
    return await _context.Rentals
      .Include(r => r.Game)
      .Include(r => r.Customer)
      .FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<List<Rental>> GetRentalsAsync()
  {
    return await _context.Rentals
      .Include(r => r.Game)
      .Include(r => r.Customer)
      .ToListAsync();
  }

  public async Task CreateRental(Rental rental)
  {
    await _context.Rentals.AddAsync(rental);
    await _context.SaveChangesAsync();
  }

  public async Task<List<Rental>> GetRentalsByGameIdWhereReturnNullAsync(int gameId)
  {
    return await _context.Rentals
      .Where(rental => rental.GameId == gameId && rental.ReturnDate == null)
      .ToListAsync();
  }
}