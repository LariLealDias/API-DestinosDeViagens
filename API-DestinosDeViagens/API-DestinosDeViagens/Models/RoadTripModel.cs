using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace API_DestinosDeViagens.Models;

public class RoadTripModel
{
    [Key]
    public int Id { get; set; }
    public int TotalDays { get; set; }
    public string Attractions { get; set; }
    public string AverageCostOfAccommodation { get; set; }
    public string AverageCostOfAlimentation { get; set; }
}
