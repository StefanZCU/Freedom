using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Areas.Admin.Controllers;

public class WorkerApprovalController : AdminBaseController
{
    private readonly IWorkerService _workerService;

    public WorkerApprovalController(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var model = await _workerService.GetPendingWorkersAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int id)
    {
        var ok = await _workerService.ApproveWorkerAsync(id);

        if (!ok)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Pending));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reject(int id)
    {
        var ok = await _workerService.RejectWorkerAsync(id);

        if (!ok)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Pending));
    }
}