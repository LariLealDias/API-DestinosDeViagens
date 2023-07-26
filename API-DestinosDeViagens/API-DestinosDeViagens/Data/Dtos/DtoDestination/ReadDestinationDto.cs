using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Data.Dtos.DtoDestination;

public class ReadDestinationDto
{
    public int Id { get; set; }
    public string PhotoPath { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string DescriptiveText { get; set; }
}
