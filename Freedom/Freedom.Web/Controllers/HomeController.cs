using System.Diagnostics;
using System.Security.Claims;
using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Freedom.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freedom.Web.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWorkerService _workerService;

    public HomeController(ILogger<HomeController> logger, IWorkerService workerService)
    {
        _logger = logger;
        _workerService = workerService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            ViewBag.HasWorker = await _workerService.WorkerAlreadyExistsAsync(User.Id());
            ViewBag.IsAdmin = User.IsInRole("Admin");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}