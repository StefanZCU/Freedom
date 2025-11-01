using Freedom.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Infrastructure.Data;

public class FreedomDbContext : IdentityDbContext
{
    public FreedomDbContext(DbContextOptions<FreedomDbContext> options)
        : base(options)
    {
    }

    public DbSet<Listing> Listings { get; set; }

    public DbSet<Worker> Workers { get; set; }

    public DbSet<WorkerTypeCategory> WorkerTypeCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}