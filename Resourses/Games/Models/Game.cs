using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Resourses.Games.Models;

[Index(nameof(Name), IsUnique = true)]
public class Game {
  public int Id { get; set;}

  [Required]
  [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
  public string Name { get; set;} = null!;

  [Required]
  [StringLength(300, ErrorMessage = "A URL da imagem deve ter no máximo 300 caracteres")]
  public string Image { get; set; } = null!;

  [Required]
  [Range(1,int.MaxValue, ErrorMessage = "O valor mínimo para StockTotal é 1")]
  public int StockTotal { get; set; }

  [Required]
  [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser no mínimo 0")]
  [Column(TypeName = "decimal(10,2)")]
  public decimal PricePerDay { get; set; }

  public ICollection<Rental> Rentals = new List<Rental>();
}