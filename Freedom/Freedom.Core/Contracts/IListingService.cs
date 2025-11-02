using Freedom.Core.Models.Listing;
using Freedom.Infrastructure.Data.Models;

namespace Freedom.Core.Contracts;

public interface IListingService
{
    Task<IEnumerable<ListingServiceModel>> GetAllAsync();

    Task<ListingDetailsServiceModel> ListingDetailsByIdAsync(int listingId);

    Task<int> CreateListingAsync(ListingFormModel model);

    Task<bool> IsOwnerAsync(int listingId, string userId);
    
    Task EditListingAsync(int listingId, ListingFormModel model);
    
    Task DeleteListingAsync(int listingId);
    
    Task<bool> ListingExistsAsync(int listingId);
}