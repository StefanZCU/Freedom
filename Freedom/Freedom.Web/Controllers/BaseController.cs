using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Controllers;

[Authorize]
public class BaseController : Controller
{
}