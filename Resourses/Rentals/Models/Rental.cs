using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using BoardcampApiCS.Resourses.Customers.Models;
using BoardcampApiCS.Resourses.Games.Models;

namespace BoardcampApiCS.Resourses.Rentals.Models;

public class Rental 
{
  public int Id { get; set; }
  public int GameId { get; set; }
  public Game Game { get; set; } = null!;
  public int CustomerId { get; set; }
  public Customer Customer { get; set; } = null!;

  [DefaultValue("GETDATE()")]
  public DateTime RentDate { get; set; }
  public int DaysRented { get; set; }
  public DateTime? ReturnDate { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float OriginalPrice { get; set; }

  [Column(TypeName = "decimal(10,2)")]
  public float? DelayFee { get; set; }
}