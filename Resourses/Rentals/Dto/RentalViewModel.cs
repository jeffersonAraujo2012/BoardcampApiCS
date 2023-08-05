using System.ComponentModel.DataAnnotations.Schema;
using BoardcampApiCS.Resourses.Customers.Dto;
using BoardcampApiCS.Resourses.Games.DTO;

namespace BoardcampApiCS.Resourses.Rentals;

public class RentalViewModel
{
  public int Id { get; set; }
  public int GameId { get; set; }
  public int CustomerId { get; set; }
  public string RentDate { get; set; } = null!;
  public int DaysRented { get; set; }
  public string? ReturnDate { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float OriginalPrice { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float? DelayFee { get; set; }

  public CustomerSimpleViewModel Customer { get; set; } = null!;
  public GameSimpleViewModel Game { get; set; } = null!;
}