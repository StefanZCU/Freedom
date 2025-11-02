using Freedom.Infrastructure.Enums;

namespace Freedom.Core.Models.Listing;

public class ListingDetailsServiceModel : ListingServiceModel
{
    public ListingStatus ListingStatus { get; set; }

    public required string Uploader { get; set; }
    
    public required string Worker { get; set; }
}