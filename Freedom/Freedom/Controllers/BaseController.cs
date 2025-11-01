using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Controllers;

[Authorize]
public class BaseController : Controller
{
}