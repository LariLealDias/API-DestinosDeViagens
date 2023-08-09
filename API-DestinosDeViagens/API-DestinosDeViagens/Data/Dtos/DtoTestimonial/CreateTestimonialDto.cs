using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoTestimonial;

public class CreateTestimonialDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Title field can't ultrapass 50 characters")]
    public string Title { get; set; }


    //[Required]
    //[MaxLength(300, ErrorMessage = "Text field can't ultrapass 300 characters")]
    public string Text { get; set; }



    //relationship 1:1
    public int CustomerModelId { get; set; }

}
