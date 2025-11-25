using System.Security.Claims;
using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Freedom.Web.Attributes.Filters;

public class MustBeAWorkerFilter : IAsyncActionFilter
{
    private readonly IWorkerService _workerService;

    public MustBeAWorkerFilter(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = context.HttpContext.User;

        if (user?.Identity == null || !user.Identity.IsAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        var userId = user.Id();
        
        var isWorker = await _workerService.WorkerAlreadyExistsAsync(userId);
        
        if (!isWorker)
        {
            context.Result = new RedirectToActionResult("Become", "Worker", null);
            return;
        }
        
        var workerId = await _workerService.GetWorkerIdByUserIdAsync(userId);

        if (!await _workerService.IsWorkerApprovedAsync(workerId))
        {
            context.Result = new RedirectToActionResult("Pending", "Worker", null);
            return;
        }

        await next();
    }
}