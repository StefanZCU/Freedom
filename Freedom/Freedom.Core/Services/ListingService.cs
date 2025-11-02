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

    public async Task<IEnumerable<ListingViewModel>> GetAllAsync()
    {
        return await _repository
            .AllReadOnly<Listing>()
            .Select(l => new ListingViewModel()
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

    public async Task<ListingViewModel> GetListingByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateListingAsync(ListingFormViewModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsOwnerAsync(int listingId, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task EditListingAsync(int listingId, ListingFormViewModel model)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteListingAsync(int listingId)
    {
        throw new NotImplementedException();
    }
}