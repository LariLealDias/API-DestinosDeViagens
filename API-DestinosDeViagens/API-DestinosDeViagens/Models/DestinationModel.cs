using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class DestinationModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "PhotoPath field can't be empty")]
    public string PhotoPath { get; set; }
    
    [Required(ErrorMessage = "Title field can't be empty")]
    [MaxLength(50, ErrorMessage = "Title field can't ultrapass 50 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Price field can't be empty")]
    public float Price { get; set; }

    [Required(ErrorMessage = "DescriptiveText field can't be empty")]
    [MaxLength(160, ErrorMessage = "DescriptiveText field can't ultrapass 160 characters")]
    public string DescriptiveText { get; set; }
}
