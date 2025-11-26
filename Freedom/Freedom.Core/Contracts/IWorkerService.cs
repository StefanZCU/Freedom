using Freedom.Core.Models.Worker;

namespace Freedom.Core.Contracts;

public interface IWorkerService
{
    Task<bool> WorkerAlreadyExistsAsync(string userId);
    
    Task CreateWorkerAsync(string userId, BecomeWorkerFormModel model);
    
    Task<int> GetWorkerIdByUserIdAsync(string userId);
    
    Task<IEnumerable<WorkerViewModel>> GetPendingWorkersAsync();
    
    Task<bool> ApproveWorkerAsync(int workerId);
    
    Task<bool> RejectWorkerAsync(int workerId);
    
    Task<bool> IsWorkerApprovedAsync(int workerId);
    
    Task<bool> IsWorkerRejectedAsync(int workerId);
    
    Task<WorkerDashboardViewModel> GetWorkerDashboardViewModelAsync(int workerId, IEnumerable<WorkerListingViewModel> workerListingViewModel);
}