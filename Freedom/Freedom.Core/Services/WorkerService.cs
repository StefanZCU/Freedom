using Freedom.Core.Contracts;
using Freedom.Core.Models.Worker;
using Freedom.Infrastructure.Data.Common;
using Freedom.Infrastructure.Data.Models;
using Freedom.Infrastructure.Enums;
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
            .AnyAsync(w => w.UserId == userId && w.WorkerStatus != WorkerStatus.Rejected);
    }

    public async Task CreateWorkerAsync(string userId, BecomeWorkerFormModel model)
    {
        var worker = new Worker()
        {
            PhoneNumber = model.PhoneNumber,
            YearsOfExperience = model.YearsOfExperience,
            WorkerTypeCategoryId = model.WorkerTypeCategoryId,
            UserId = userId,
            WorkerStatus = WorkerStatus.Pending
        };
        
        await _repository.AddAsync(worker);
        await _repository.SaveChangesAsync();
    }

    public async Task<int> GetWorkerIdByUserIdAsync(string userId)
    {
        return await _repository
            .AllReadOnly<Worker>()
            .Where(w => w.UserId == userId)
            .Select(w => w.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<WorkerViewModel>> GetPendingWorkersAsync()
    {
        return await _repository.AllReadOnly<Worker>()
            .Where(w => w.WorkerStatus == WorkerStatus.Pending)
            .Select(w => new WorkerViewModel()
            {
                Id = w.Id,
                PhoneNumber = w.PhoneNumber,
                YearsOfExperience = w.YearsOfExperience,
                WorkerTypeCategory = w.WorkerTypeCategory.Name
            })
            .ToListAsync();
    }

    public async Task<bool> ApproveWorkerAsync(int workerId)
    {
        var worker = await _repository.GetByIdAsync<Worker>(workerId);
        
        if (worker == null) return false;
        
        worker.WorkerStatus = WorkerStatus.Active;
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RejectWorkerAsync(int workerId)
    {
        var worker = await _repository.GetByIdAsync<Worker>(workerId);
        
        if (worker == null) return false;
        
        worker.WorkerStatus = WorkerStatus.Rejected;
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsWorkerApprovedAsync(int workerId)
    {
        return await _repository.AllReadOnly<Worker>().AnyAsync(w => w.Id == workerId && w.WorkerStatus == WorkerStatus.Active);
    }

    public async Task<bool> IsWorkerRejectedAsync(int workerId)
    {
        return await _repository.AllReadOnly<Worker>()
            .AnyAsync(w => w.Id == workerId && w.WorkerStatus == WorkerStatus.Rejected);
    }
}