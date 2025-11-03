using Freedom.Infrastructure.Enums;

namespace Freedom.Core.Models.Listing;

public class ListingFilterModel
{
    public int? CategoryId { get; set; }
    
    public decimal? MinBudget { get; set; }
    
    public decimal? MaxBudget { get; set; }
    
    public ListingStatus? Status { get; set; }
    
    public string? SearchTerm { get; set; }
    
    public int Page { get; set; } = 1;
    
    public int PageSize { get; set; } = 12;
}