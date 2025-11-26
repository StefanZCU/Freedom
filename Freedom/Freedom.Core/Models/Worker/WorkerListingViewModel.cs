using System.ComponentModel.DataAnnotations;
using Freedom.Infrastructure.Enums;

namespace Freedom.Core.Models.Worker;

public class WorkerListingViewModel
{
    public int Id { get; set; }
    
    public required string Title { get; set; }
    
    public decimal Budget { get; set; }
    
    [Display(Name = "Location address")]
    public required string LocationAddress { get; set; }
    
    [Display(Name = "Listing status")]
    public ListingStatus ListingStatus { get; set; }

    [Display(Name = "Uploader email")]
    public required string UploaderEmail { get; set; }
}