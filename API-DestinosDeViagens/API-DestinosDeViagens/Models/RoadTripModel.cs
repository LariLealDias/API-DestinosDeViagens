using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class RoadTripModel
{
    [Key]
    public int Id { get; set; }
    public int TotalDays { get; set; }
    public string Sights { get; set; }
    public string AverageAccommodationPrice { get; set; }
    public string AverageMealPrice { get; set; }
}
