using System.ComponentModel.DataAnnotations.Schema;
using BoardcampApiCS.Resourses.Games.Models;

namespace BoardcampApiCS.Resourses.Rentals.Models;

public class Rental 
{
  public int Id { get; set; }
  public int GameId { get; set; }
  public Game Game { get; set; } = null!;
  public DateTime RentDate { get; set; }
  public int DaysRented { get; set; }
  public DateTime? ReturnDate { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public decimal OriginalPrice { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public decimal? DelayFee { get; set; }
}