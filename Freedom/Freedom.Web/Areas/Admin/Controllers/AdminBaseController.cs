using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Freedom.Core.Constants.AdministratorConstants;


namespace Freedom.Web.Areas.Admin.Controllers;

[Area(AdminAreaName)]
[Authorize(Roles = AdminRole)]
public class AdminBaseController : Controller
{
    
}