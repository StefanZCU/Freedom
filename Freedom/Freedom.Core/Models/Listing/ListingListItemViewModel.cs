namespace Freedom.Core.Models.Listing;

public class ListingListItemViewModel
{
    public int Id { get; set; }
    
    public string Title { get; set; } = "";
    
    public decimal Budget { get; set; }
    
    public string LocationAddress { get; set; } = "";
    
    public int WorkerTypeCategoryId { get; set; }
}