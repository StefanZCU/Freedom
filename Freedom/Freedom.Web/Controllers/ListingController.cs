using System.Security.Claims;
using Freedom.Core.Contracts;
using Freedom.Core.Models.Listing;
using Freedom.Infrastructure.Data.Models;
using Freedom.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Controllers;

public class ListingController : BaseController
{
    private readonly IListingService _listingService;
    private readonly IWorkerService _workerService;

    public ListingController(IListingService listingService, IWorkerService workerService)
    {
        _listingService = listingService;
        _workerService = workerService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index([FromQuery] ListingFilterModel filter)
    {
        var categories = await _listingService.AllWorkerTypeCategoriesAsync();
        var (items, total) = await _listingService.AllAsync(filter);

        var vm = new ListingIndexViewModel
        {
            Filter = filter,
            Categories = categories.Select(c => new WorkerTypeCategory() { Id = c.Id, Name = c.Name }).ToList(),
            Items = items,
            TotalCount = total
        };

        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int listingId)
    {
        if (!await _listingService.ListingExistsAsync(listingId))
        {
            return NotFound();
        }
        
        var model = await _listingService.ListingDetailsByIdAsync(listingId);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View(new ListingFormModel()
        {
            Title = string.Empty,
            Description = string.Empty,
            LocationAddress = string.Empty,
            WorkerTypeCategories = await _listingService.AllWorkerTypeCategoriesAsync()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ListingFormModel model)
    {
        if (!await _listingService.WorkerTypeCategoryExistsAsync(model.WorkerTypeCategoryId))
        {
            ModelState.AddModelError(nameof(model.WorkerTypeCategoryId),  "Select a valid worker type category.");
        }
        
        if (!ModelState.IsValid)
        {
            model.WorkerTypeCategories = await _listingService.AllWorkerTypeCategoriesAsync();
            return View(model);
        }

        var newListingId = await _listingService.CreateListingAsync(model, User.Id());
        
        return RedirectToAction("Details", new { listingId = newListingId });
    }

    [HttpGet]
    [MustBeUploader]
    public async Task<IActionResult> Edit(int listingId)
    {
        if (!await _listingService.ListingExistsAsync(listingId))
        {
            return NotFound();
        }
        
        var model = await _listingService.GetListingFormModelByIdAsync(listingId);
        
        ViewBag.ListingId = listingId;
        return View(model);
    }

    [HttpPost]
    [MustBeUploader]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int listingId, ListingFormModel model)
    {
        if (!await _listingService.WorkerTypeCategoryExistsAsync(model.WorkerTypeCategoryId))
        {
            ModelState.AddModelError(nameof(model.WorkerTypeCategoryId),  "Select a valid worker type category.");
        }

        if (!ModelState.IsValid)
        {
            model.WorkerTypeCategories = await _listingService.AllWorkerTypeCategoriesAsync();
            ViewBag.ListingId = listingId;
            return View(model);
        }
        
        var ok = await _listingService.EditListingAsync(listingId, model, User.Id());

        if (!ok)
        {
            return NotFound();
        }
        
        return RedirectToAction(nameof(Details), new { listingId });
    }
    
    [HttpPost]
    [MustBeUploader]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int listingId)
    {
        var ok = await _listingService.DeleteListingAsync(listingId, User.Id());

        if (!ok)
        {
            return BadRequest();
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [MustBeAWorker]
    public async Task<IActionResult> Assign(int listingId)
    {
        var workerId = await _workerService.GetWorkerIdByUserIdAsync(User.Id());
        
        var ok = await _listingService.AssignListingToWorkerAsync(listingId, workerId);

        if (!ok)
        {
            return BadRequest();
        }
        
        return RedirectToAction(nameof(Details), new { listingId });
    }

    [HttpGet]
    [MustBeAWorker]
    public async Task<IActionResult> Complete(int listingId)
    {
        var workerId = await _workerService.GetWorkerIdByUserIdAsync(User.Id());
        
        var ok = await _listingService.CompleteListingAsync(listingId, workerId);

        if (!ok)
        {
            return BadRequest();
        }
        
        return RedirectToAction(nameof(Details), new { listingId });
    }
    
}