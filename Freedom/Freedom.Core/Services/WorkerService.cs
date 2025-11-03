using Freedom.Core.Contracts;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Common;
using Freedom.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Core.Services;

public class WorkerService : IWorkerService
{
    private readonly IRepository _repository;

    public WorkerService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> WorkerAlreadyExistsAsync(string userId)
    {
        return await _repository
            .AllReadOnly<Worker>()
            .AnyAsync(w => w.UserId == userId);
    }

    public async Task CreateWorkerAsync(string userId, BecomeWorkerFormModel model)
    {
        var worker = new Worker()
        {
            PhoneNumber = model.PhoneNumber,
            YearsOfExperience = model.YearsOfExperience,
            WorkerTypeCategoryId = model.WorkerTypeCategoryId,
            UserId = userId
        };
        
        await _repository.AddAsync(worker);
        await _repository.SaveChangesAsync();
    }
}