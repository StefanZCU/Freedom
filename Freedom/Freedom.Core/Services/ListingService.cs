using Freedom.Core.Contracts;
using Freedom.Core.Models.Listing;
using Freedom.Infrastructure.Data.Common;
using Freedom.Infrastructure.Data.Models;
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

    public async Task<int> CreateListingAsync(ListingFormModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsOwnerAsync(int listingId, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task EditListingAsync(int listingId, ListingFormModel model)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteListingAsync(int listingId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ListingExistsAsync(int listingId)
        => _repository.AllReadOnly<Listing>().AnyAsync(l => l.Id == listingId);
}