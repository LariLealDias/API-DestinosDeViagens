using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class TestimonialModel
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "Title field can't be empty")]
    [MaxLength(50, ErrorMessage = "Title field can't ultrapass 50 characters")]
    public string Title { get; set; }


    public string Text { get; set; }

    //1:1
    public int CustomerModelId { get; set; }
    public virtual CustomerModel CustomerModel { get; set; }
}