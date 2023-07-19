using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoDestination;

public class ReadDestionationDto
{
    public int Id { get; set; }
    public string PhotoPath { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
}
