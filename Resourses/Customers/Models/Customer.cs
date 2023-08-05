using System.ComponentModel.DataAnnotations;
using BoardcampApiCS.Resourses.Rentals.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardcampApiCS.Resourses.Customers.Models;

[Index(nameof(Cpf), IsUnique = true)]
public class Customer
{
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public string Name { get; set; } = null!;

  [Required]
  [StringLength(11, ErrorMessage = "O numero de telefone deve ter no máximo 11 dígitos")]
  public string Phone { get; set; } = null!;

  [Required]
  [StringLength(11, ErrorMessage = "O cpf deve ter apenas 11 dígitos")]
  public string Cpf { get; set; } = null!;

  [Required]
  public DateTime Birthday { get; set; }

  public ICollection<Rental> Rentals = new List<Rental>();
}