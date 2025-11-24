using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Areas.Admin.Controllers;

public class ListingApprovalController : AdminBaseController
{
    private readonly IListingService _listingService;

    public ListingApprovalController(IListingService listingService)
    {
        _listingService = listingService;
    }

    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var model = await _listingService.GetPendingListingsAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int id)
    {
        var ok = await _listingService.ApproveListingAsync(id);

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
        var ok = await _listingService.RejectListingAsync(id);

        if (!ok)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Pending));
    }
}