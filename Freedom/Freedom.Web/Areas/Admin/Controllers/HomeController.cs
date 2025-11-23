using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}