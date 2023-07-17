using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoTestimonial;

public class UpdateTestimonialDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Title field can't ultrapass 50 characters")]
    public string Title { get; set; }


    [Required]
    [MaxLength(300, ErrorMessage = "Text field can't ultrapass 300 characters")]
    public string Text { get; set; }

}
