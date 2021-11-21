using System.ComponentModel.DataAnnotations;

namespace AnimalAPI.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    [StringLength(100)]
    public string Family { get; set; }
    [Required]
    [StringLength(999)]
    public string Age { get; set; }
    [Required]
    [StringLength(6)]
    public string Sex { get; set; }
    [Required]
    [StringLength(10)]
    public string Admission { get; set; }
    [Required]
    [StringLength(100)]
    public string Breed { get; set; }
    [Required]
    [StringLength(200)]
    public string Review { get; set; }
    [Required]
    [StringLength(10)]
    public string UserName { get; set; }
  }
}