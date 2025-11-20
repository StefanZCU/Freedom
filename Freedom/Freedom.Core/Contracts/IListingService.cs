using Freedom.Core.Models.Listing;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Models;

namespace Freedom.Core.Contracts;

public interface IListingService
{
    Task<(IEnumerable<ListingListItemViewModel> Items, int TotalCount)> AllAsync(ListingFilterModel filter);

    Task<ListingDetailsServiceModel> ListingDetailsByIdAsync(int listingId);
    
    Task<IEnumerable<WorkerTypeCategoryServiceModel>> AllWorkerTypeCategoriesAsync();
    
    Task<bool> WorkerTypeCategoryExistsAsync(int workerTypeCategoryId);

    Task<int> CreateListingAsync(ListingFormModel model, string userId);
    
    Task<ListingFormModel> GetListingFormModelByIdAsync(int listingId);

    Task<bool> IsOwnerAsync(int listingId, string userId);
    
    Task<bool> EditListingAsync(int listingId, ListingFormModel model, string userId);
    
    Task<bool> DeleteListingAsync(int listingId, string userId);
    
    Task<bool> ListingExistsAsync(int listingId);
    
    Task<bool> AssignListingToWorkerAsync(int listingId, int workerId);
    
    Task<bool> CompleteListingAsync(int listingId, int workerId);

    Task<IEnumerable<ListingListItemViewModel>> GetListingByUserIdAsync(string userId);
    
}