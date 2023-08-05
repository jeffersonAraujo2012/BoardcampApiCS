using System.ComponentModel.DataAnnotations;

namespace BoardcampApiCS.Resourses.Rentals.Dto;

public class AddRentalInputModel
{
  [Required]
  public int CustomerId { get; set; }

  [Required]
  public int GameId { get; set; }

  [Required]
  public int DaysRented { get; set; }
}