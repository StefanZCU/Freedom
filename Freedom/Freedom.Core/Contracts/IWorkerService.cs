using Freedom.Core.Models.Worker;

namespace Freedom.Core.Contracts;

public interface IWorkerService
{
    Task<bool> WorkerAlreadyExistsAsync(string userId);
    
    Task CreateWorkerAsync(string userId, BecomeWorkerFormModel model);
    
    Task<int> GetWorkerIdByUserIdAsync(string userId);
}