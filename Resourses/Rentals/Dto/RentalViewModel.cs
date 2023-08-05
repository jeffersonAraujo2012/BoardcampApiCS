using System.ComponentModel.DataAnnotations.Schema;
using BoardcampApiCS.Resourses.Rentals.Models;

namespace BoardcampApiCS.Resourses.Rentals;

public class RentalViewModel
{
  public int Id { get; set; }
  public int GameId { get; set; }
  public string RentDate { get; set; } = null!;
  public int DaysRented { get; set; }
  public string? ReturnDate { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float OriginalPrice { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float? DelayFee { get; set; }
}