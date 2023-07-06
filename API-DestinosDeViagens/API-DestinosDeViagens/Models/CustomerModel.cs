using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class CustomerModel
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "Photo fild can't be empty")]
    public string PhotoPath { get; set; }


    [Required(ErrorMessage = "Name fild can't be empty")]
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name fild must be only letters")]
    public string Name { get; set; }

    public virtual TestimonialModel TestimonialModel { get; set; }
}
