using System.ComponentModel.DataAnnotations;

namespace Freedom.Core.Models.Listing;

public class ListingListItemViewModel
{
    public int Id { get; set; }
    
    public string Title { get; set; } = "";
    
    public decimal Budget { get; set; }
    
    [Display(Name = "Location Address")]
    public required string LocationAddress { get; set; } 
    
    public int WorkerTypeCategoryId { get; set; }

    public string WorkerTypeCategoryName { get; set; } = "";
    
    public bool IsApproved { get; set; }
}