using System.Security.Claims;
using Freedom.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Freedom.Web.Attributes.Filters;

// 1. User must be logged in
// 2. Get listing id from action arguments
// 3. Ask service if the current user is uploader
// 4. If not, block

public class MustBeUploaderFilter : IAsyncActionFilter
{
    private readonly IListingService _listingService;

    public MustBeUploaderFilter(IListingService listingService)
    {
        _listingService = listingService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = context.HttpContext.User;

        if (user?.Identity?.IsAuthenticated == false)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        var userId = user.Id();

        if (!context.ActionArguments.TryGetValue("listingId", out var idObj) || idObj is not int listingId)
        {
            context.Result = new BadRequestResult();
            return;
        }
        
        var isUploader = await _listingService.IsOwnerAsync(listingId, userId);

        if (!isUploader)
        {
            context.Result = new ForbidResult();
            return;
        }
        
        await next();
    }
}