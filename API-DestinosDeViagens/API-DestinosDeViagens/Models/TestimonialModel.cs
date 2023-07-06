using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class TestimonialModel
{
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(300, ErrorMessage = "Text fild can't ultrapass 300 characters")]
    public string Text { get; set; }

    //1:1
    public int CustomerModelId { get; set; }
    public virtual CustomerModel CustomerModel { get; set; }
}