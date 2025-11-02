using System.ComponentModel.DataAnnotations;
using Freedom.Infrastructure.Data.Models;
using Freedom.Infrastructure.Enums;

namespace Freedom.Core.Models.Listing;

public class ListingViewModel
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }
    
    [Display(Name = "Location Address")]
    public required string LocationAddress { get; set; }
    
    public decimal Budget { get; set; }
    
    public required string WorkerTypeCategory { get; set; }
}