using System.Security.Claims;
using Freedom.Core.Contracts;
using Freedom.Core.Models.Worker;
using Freedom.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Controllers;

public class WorkerController : BaseController
{
    private readonly IWorkerService _workerService;
    private readonly IListingService _listingService;

    public WorkerController(IWorkerService workerService, IListingService listingService)
    {
        _workerService = workerService;
        _listingService = listingService;
    }

    [MustBeAWorker]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Become()
    {
        var userId = User.Id();

        if (await _workerService.WorkerAlreadyExistsAsync(userId))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var model = new BecomeWorkerFormModel()
        {
            PhoneNumber = string.Empty,
            WorkerTypeCategories = await _listingService.AllWorkerTypeCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Become(BecomeWorkerFormModel model)
    {
        var userId = User.Id();

        if (await _workerService.WorkerAlreadyExistsAsync(userId))
        {
            ModelState.AddModelError("UserId", "User with this Id is already a worker.");
        }

        if (!ModelState.IsValid)
        {
            model.PhoneNumber = string.Empty;
            return View(model);
        }

        await _workerService.CreateWorkerAsync(userId, model);
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var userId = User.Id();
        
        var isWorker = await _workerService.WorkerAlreadyExistsAsync(userId);

        if (!isWorker)
        {
            return RedirectToAction(nameof(Become));
        }
        
        var workerId = await _workerService.GetWorkerIdByUserIdAsync(User.Id());
        
        if (await _workerService.IsWorkerApprovedAsync(workerId))
        {
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }
}