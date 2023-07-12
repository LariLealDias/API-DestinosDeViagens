using API_DestinosDeViagens.Data.Dtos.DtoCustomer;
using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoTestimonial;

public class ReadTestimonialDto
{
    public string PhotoPath { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Name { get; set; }

    public ReadCustomerDto ReadCustomerDto { get; set; }
}
