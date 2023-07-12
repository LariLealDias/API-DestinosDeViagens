using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoCustomer;

public class ReadCustomerDto
{
    public int Id { get; set; }
    public string PhotoPath { get; set; }
    public string Name { get; set; }
}
