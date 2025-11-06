using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IListingService _listingService;
    private readonly IWorkerService _workerService;

    public AdminController(IListingService listingService, IWorkerService workerService)
    {
        _listingService = listingService;
        _workerService = workerService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}