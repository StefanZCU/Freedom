using Freedom.Core.Models.Listing;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Models;

namespace Freedom.Core.Contracts;

public interface IListingService
{
    Task<IEnumerable<ListingServiceModel>> GetAllAsync();

    Task<ListingDetailsServiceModel> ListingDetailsByIdAsync(int listingId);
    
    Task<IEnumerable<WorkerTypeCategoryServiceModel>> AllWorkerTypeCategoriesAsync();
    
    Task<bool> WorkerTypeCategoryExistsAsync(int workerTypeCategoryId);

    Task<int> CreateListingAsync(ListingFormModel model, string userId);
    
    Task<ListingFormModel> GetListingFormModelByIdAsync(int listingId);

    Task<bool> IsOwnerAsync(int listingId, string userId);
    
    Task<bool> EditListingAsync(int listingId, ListingFormModel model);
    
    Task DeleteListingAsync(int listingId);
    
    Task<bool> ListingExistsAsync(int listingId);
}