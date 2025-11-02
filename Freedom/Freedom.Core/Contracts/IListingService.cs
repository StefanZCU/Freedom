using Freedom.Core.Models.Listing;

namespace Freedom.Core.Contracts;

public interface IListingService
{
    Task<IEnumerable<ListingViewModel>> GetAllAsync();

    Task<ListingViewModel> GetListingByIdAsync(int id);

    Task<int> CreateListingAsync(ListingFormViewModel model);

    Task<bool> IsOwnerAsync(int listingId, string userId);
    
    Task EditListingAsync(int listingId, ListingFormViewModel model);
    
    Task DeleteListingAsync(int listingId);
}