using Freedom.Core.Contracts;
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

    public async Task<IEnumerable<ListingServiceModel>> GetAllAsync()
    {
        return await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.ListingStatus == ListingStatus.Active)
            .Select(l => new ListingServiceModel()
            {
                Id = l.Id,
                Title = l.Title,
                Description = l.Description,
                LocationAddress = l.LocationAddress,
                Budget = l.Budget,
                WorkerTypeCategory = l.WorkerTypeCategory.Name
            })
            .ToListAsync();
    }

    public async Task<ListingDetailsServiceModel> ListingDetailsByIdAsync(int listingId)
    {
        return await _repository
            .AllReadOnly<Listing>()
            .Where(l => l.Id == listingId)
            .Select(l => new ListingDetailsServiceModel()
            {
                Id = l.Id,
                Title = l.Title,
                Description = l.Description,
                LocationAddress = l.LocationAddress,
                Budget = l.Budget,
                WorkerTypeCategory = l.WorkerTypeCategory.Name,
                ListingStatus = l.ListingStatus,
                Uploader = l.Uploader.UserName,
                Worker = l.Worker.User.UserName ?? "No worker assigned"
            })
            .FirstAsync();
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

    public async Task<bool> EditListingAsync(int listingId, ListingFormModel model, string userId)
    {
        var listing = await _repository
            .All<Listing>()
            .FirstOrDefaultAsync(l => l.Id == listingId 
                                      && l.ListingStatus == ListingStatus.Active
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
}