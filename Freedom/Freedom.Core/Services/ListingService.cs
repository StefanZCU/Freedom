using Freedom.Core.Contracts;
using Freedom.Core.Enums;
using Freedom.Core.Models.Listing;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Common;
using Freedom.Infrastructure.Data.Models;
using Freedom.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Core.Services;

public class ListingService : IListingService
{
    private readonly IRepository _repository;

    public ListingService(
        IRepository repository)
    {
        _repository = repository;
    }

    public async Task<(IEnumerable<ListingListItemViewModel> Items, int TotalCount)> AllAsync(ListingFilterModel f)
    {
        var query = _repository.AllReadOnly<Listing>();

        query = query.Where(l => l.IsApproved);

        var status = f.Status ?? ListingStatus.Active;
        query = query.Where(l => l.ListingStatus == status);
        
        var searchTerm = f.SearchTerm?.Trim();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(l => l.Title.Contains(searchTerm) || l.Description.Contains(searchTerm));
        }

        query = f.SortBy switch
        { 
            ListingSortOptions.BudgetAsc => query.OrderBy(l => l.Budget),
            ListingSortOptions.BudgetDesc => query.OrderByDescending(l => l.Budget),
            _ => query.OrderByDescending(l => l.Id)
        };

        if (f.CategoryId is int catId)
            query = query.Where(l => l.WorkerTypeCategoryId == catId);

        if (f.MinBudget is decimal min)
            query = query.Where(l => l.Budget >= min);

        if (f.MaxBudget is decimal max)
            query = query.Where(l => l.Budget <= max);

        var total = await query.CountAsync();

        var items = await query
            .Skip((f.Page - 1) * f.PageSize)
            .Take(f.PageSize)
            .Select(l => new ListingListItemViewModel()
            {
                Id = l.Id,
                Title = l.Title,
                Budget = l.Budget,
                LocationAddress = l.LocationAddress,
                WorkerTypeCategoryId = l.WorkerTypeCategoryId
            })
            .ToListAsync();

        return (items, total);
    }

    public async Task<ListingDetailsServiceModel?> GetListingDetailsForUserAsync(int listingId, string userId, bool isAdmin)
    {
        var listing = await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.Id == listingId 
                && (l.IsApproved 
                    || isAdmin 
                    || l.UploaderId == userId))
            .Select(l => new ListingDetailsServiceModel()
            {
                Budget = l.Budget,
                Description = l.Description,
                Id = l.Id,
                LocationAddress = l.LocationAddress,
                Title = l.Title,
                ListingStatus = l.ListingStatus,
                Uploader = l.Uploader.UserName,
                WorkerTypeCategory = l.WorkerTypeCategory.Name,
                Worker = l.Worker != null 
                    ? l.Worker.User.UserName 
                    : "No worker assigned yet."
            })
            .FirstOrDefaultAsync();

        return listing;
    }

    public async Task<IEnumerable<WorkerTypeCategoryServiceModel>> AllWorkerTypeCategoriesAsync()
    {
        return await _repository.AllReadOnly<WorkerTypeCategory>()
            .Select(wtc => new WorkerTypeCategoryServiceModel()
            {
                Id = wtc.Id,
                Name = wtc.Name
            })
            .ToListAsync();
    }

    public async Task<bool> WorkerTypeCategoryExistsAsync(int workerTypeCategoryId)
        => await _repository.AllReadOnly<WorkerTypeCategory>().AnyAsync(wtc => wtc.Id == workerTypeCategoryId);


    public async Task<int> CreateListingAsync(ListingFormModel model, string userId)
    {
        var listing = new Listing()
        {
            Title = model.Title,
            Description = model.Description,
            LocationAddress = model.LocationAddress,
            Budget = model.Budget,
            WorkerTypeCategoryId = model.WorkerTypeCategoryId,
            UploaderId = userId
        };

        await _repository.AddAsync(listing);
        await _repository.SaveChangesAsync();

        return listing.Id;
    }

    public async Task<ListingFormModel> GetListingFormModelByIdAsync(int listingId)
    {
        var listing = await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.Id == listingId)
            .Select(l => new ListingFormModel()
            {
                Title = l.Title,
                Description = l.Description,
                LocationAddress = l.LocationAddress,
                Budget = l.Budget,
                WorkerTypeCategoryId = l.WorkerTypeCategoryId
            })
            .FirstAsync();

        listing.WorkerTypeCategories = await AllWorkerTypeCategoriesAsync();

        return listing;
    }

    public async Task<bool> IsOwnerAsync(int listingId, string userId)
    {
        return await _repository.AllReadOnly<Listing>()
            .AnyAsync(l => l.Id == listingId && l.UploaderId == userId);
    }

    public async Task<bool> IsWorkerAssignedAsync(int listingId)
    {
        return await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.Id == listingId && l.WorkerId != null)
            .AnyAsync();
    }

    public async Task<bool> EditListingAsync(int listingId, ListingFormModel model, string userId)
    {
        var listing = await _repository
            .All<Listing>()
            .FirstOrDefaultAsync(l => l.Id == listingId
                                      && l.WorkerId == null
                                      && l.UploaderId == userId);

        if (listing == null)
        {
            return false;
        }

        listing.Title = model.Title.Trim();
        listing.Description = model.Description.Trim();
        listing.LocationAddress = model.LocationAddress.Trim();
        listing.Budget = model.Budget;
        listing.WorkerTypeCategoryId = model.WorkerTypeCategoryId;

        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteListingAsync(int listingId, string userId)
    {
        var listing = await _repository
            .All<Listing>()
            .FirstOrDefaultAsync(l => l.Id == listingId 
                                 && l.ListingStatus == ListingStatus.Active
                                 && l.WorkerId == null
                                 && l.UploaderId == userId);

        if (listing == null) return false;
        
        listing.ListingStatus = ListingStatus.Archived;
        await _repository.SaveChangesAsync();
        return true;

    }

    public Task<bool> ListingExistsAsync(int listingId)
        => _repository.AllReadOnly<Listing>().AnyAsync(l => l.Id == listingId);
    
    public async Task<bool> AssignListingToWorkerAsync(int listingId, int workerId)
    {
        var listing = await _repository
            .All<Listing>()
            .FirstOrDefaultAsync(l => l.Id == listingId);

        if (listing == null)
        {
            return false;
        }

        if (listing.ListingStatus != ListingStatus.Active)
        {
            return false;
        }

        if (listing.WorkerId != null)
        {
            return false;
        }

        var worker = await _repository
            .AllReadOnly<Worker>()
            .Where(w => w.Id == workerId)
            .FirstOrDefaultAsync();

        if (worker != null && worker.WorkerTypeCategoryId != listing.WorkerTypeCategoryId)
        {
            return false;
        }
        
        if (await IsOwnerAsync(listingId, worker.UserId))
        {
            return false;
        }

        listing.WorkerId = workerId;
        listing.ListingStatus = ListingStatus.Assigned;

        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CompleteListingAsync(int listingId, int workerId)
    {
        var listing = await _repository
            .All<Listing>()
            .FirstOrDefaultAsync(l => l.Id == listingId);

        if (listing?.WorkerId == null || listing.WorkerId != workerId)
        {
            return false;
        }

        if (listing.ListingStatus != ListingStatus.Assigned)
        {
            return false;
        }
        
        var workerUserId = await _repository
            .AllReadOnly<Worker>()
            .Where(w => w.Id == workerId)
            .Select(w => w.UserId)
            .FirstOrDefaultAsync();

        if (workerUserId != null && await IsOwnerAsync(listingId, workerUserId))
        {
            return false;
        }

        listing.ListingStatus = ListingStatus.Completed;

        await _repository.SaveChangesAsync();
        return true;

    }

    public async Task<IEnumerable<ListingListItemViewModel>> GetListingByUserIdAsync(string userId)
    {
        var listings = await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.UploaderId == userId && l.ListingStatus != ListingStatus.Archived)
            .Select(l => new ListingListItemViewModel()
            {
                Id = l.Id,
                Budget = l.Budget,
                LocationAddress = l.LocationAddress,
                Title = l.Title,
                WorkerTypeCategoryId = l.WorkerTypeCategoryId,
                IsApproved = l.IsApproved,
                ListingStatus = l.ListingStatus.ToString()
            })
            .ToListAsync();

        return listings;
    }

    public async Task<IEnumerable<ListingListItemViewModel>> GetPendingListingsAsync()
    {
        return await _repository
            .AllReadOnly<Listing>()
            .Where(l => !l.IsApproved && l.ListingStatus == ListingStatus.Pending)
            .Select(l => new ListingListItemViewModel()
            {
                Id = l.Id,
                Budget = l.Budget,
                LocationAddress = l.LocationAddress,
                Title = l.Title,
                WorkerTypeCategoryId = l.WorkerTypeCategoryId,
                WorkerTypeCategoryName = l.WorkerTypeCategory.Name
            })
            .ToListAsync();
    }

    public async Task<bool> ApproveListingAsync(int listingId)
    {
        var listing = await _repository.GetByIdAsync<Listing>(listingId);
        
        if (listing == null) return false;
        
        listing.IsApproved = true;
        listing.ListingStatus = ListingStatus.Active;
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RejectListingAsync(int listingId)
    {
        var listing = await _repository.GetByIdAsync<Listing>(listingId);
        
        if (listing == null) return false;

        listing.ListingStatus = ListingStatus.Rejected;
        await _repository.SaveChangesAsync();
        return true;
    }
}