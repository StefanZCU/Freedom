using Freedom.Core.Models.Listing;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Models;

namespace Freedom.Core.Contracts;

public interface IListingService
{
    Task<(IEnumerable<ListingListItemViewModel> Items, int TotalCount)> AllAsync(ListingFilterModel filter);

    Task<ListingDetailsServiceModel?> GetListingDetailsForUserAsync(int listingId, string userId, bool isAdmin);
    
    Task<IEnumerable<WorkerTypeCategoryServiceModel>> AllWorkerTypeCategoriesAsync();
    
    Task<bool> WorkerTypeCategoryExistsAsync(int workerTypeCategoryId);

    Task<int> CreateListingAsync(ListingFormModel model, string userId);
    
    Task<ListingFormModel> GetListingFormModelByIdAsync(int listingId);

    Task<bool> IsOwnerAsync(int listingId, string userId);
    
    Task<bool> IsWorkerAssignedAsync(int listingId);
    
    Task<bool> EditListingAsync(int listingId, ListingFormModel model, string userId);
    
    Task<bool> DeleteListingAsync(int listingId, string userId);
    
    Task<bool> ListingExistsAsync(int listingId);
    
    Task<bool> AssignListingToWorkerAsync(int listingId, int workerId);
    
    Task<bool> CompleteListingAsync(int listingId, int workerId);

    Task<IEnumerable<ListingListItemViewModel>> GetListingByUserIdAsync(string userId);
    
    Task<IEnumerable<ListingListItemViewModel>> GetPendingListingsAsync();
    
    Task<bool> ApproveListingAsync(int listingId);
    
    Task<bool> RejectListingAsync(int listingId);
    
}