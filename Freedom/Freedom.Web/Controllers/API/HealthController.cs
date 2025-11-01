using Freedom.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Controllers.API;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly FreedomDbContext _context;
    private readonly IHostEnvironment _environment;
    
    public HealthController(
        FreedomDbContext context,
        IHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    [HttpGet]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public async Task<ActionResult> GetAsync()
    {
        if (!_environment.IsDevelopment())
        {
            return NotFound();
        }
        
        var dbConnected = await _context.Database.CanConnectAsync();
        
        return Ok(new
        {
            Application = "Freedom",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
            DatabaseConnected = dbConnected,
            Utc = DateTime.UtcNow
        });
    }
}