using System.ComponentModel.DataAnnotations;

namespace BoardcampApiCS.Resourses.Customers.Dto;

public class CustomerInputModel {
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
}