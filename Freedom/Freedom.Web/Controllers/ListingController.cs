using Freedom.Core.Contracts;
using Freedom.Core.Models.Listing;
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

    public async Task<IActionResult> Index()
    {
        var model = await _listingService.GetAllAsync();
        return View(model);
    }

    public async Task<IActionResult> Details(int listingId)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ListingFormViewModel model)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int listingId)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int listingId, ListingFormViewModel model)
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int listingId)
    {
        return View();
    }
}