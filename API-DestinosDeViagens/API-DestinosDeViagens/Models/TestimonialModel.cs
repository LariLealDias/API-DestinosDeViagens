using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class TestimonialModel
{
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(50, ErrorMessage = "Title field can't ultrapass 50 characters")]
    public string Title { get; set; }


    [Required]
    [MaxLength(300, ErrorMessage = "Text field can't ultrapass 300 characters")]
    public string Text { get; set; }

    //1:1
    public int CustomerModelId { get; set; }
    public virtual CustomerModel CustomerModel { get; set; }
}