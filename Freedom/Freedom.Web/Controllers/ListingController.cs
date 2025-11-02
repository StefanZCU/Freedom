using Freedom.Core.Contracts;
using Freedom.Core.Models.Listing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Controllers;

public class ListingController : BaseController
{
    private readonly IListingService _listingService;

    public ListingController(
        IListingService listingService)
    {
        _listingService = listingService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var model = await _listingService.GetAllAsync();
        return View(model);
    }

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
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ListingFormModel model)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int listingId)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int listingId, ListingFormModel model)
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int listingId)
    {
        return View();
    }
}