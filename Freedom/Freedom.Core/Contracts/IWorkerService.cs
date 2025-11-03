using Freedom.Core.Models.Worker;

namespace Freedom.Core.Contracts;

public interface IWorkerService
{
    Task<bool> WorkerAlreadyExistsAsync(string workerId);
    
    Task CreateWorkerAsync(string userId, BecomeWorkerFormModel model);
}