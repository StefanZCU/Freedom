using Freedom.Infrastructure.Data.Models;

namespace Freedom.Core.Models.Listing;

public class ListingIndexViewModel
{
    public ListingFilterModel Filter { get; set; } = new();
    
    public List<WorkerTypeCategory> Categories { get; set; } = [];
    
    public IEnumerable<ListingListItemViewModel> Items { get; set; } = [];
    
    public int TotalCount { get; set; }
}