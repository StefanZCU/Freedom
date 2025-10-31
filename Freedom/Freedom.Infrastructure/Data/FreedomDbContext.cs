using Freedom.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Infrastructure.Data;

public class FreedomDbContext : IdentityDbContext<ApplicationUser>
{
    public FreedomDbContext(DbContextOptions<FreedomDbContext> options)
        : base(options)
    {
    }

    public DbSet<Listing> Listings { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Worker> Workers { get; set; }

    public DbSet<WorkerTypeCategory> WorkerTypeCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Listing>()
            .HasOne(l => l.Uploader)
            .WithMany()
            .HasForeignKey(l => l.UploaderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Review>()
            .HasOne(r => r.Listing)
            .WithMany()
            .HasForeignKey(r => r.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Review>()
            .HasOne(r => r.Reviewer)
            .WithMany()
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<Review>()
            .HasOne(r => r.Worker)
            .WithMany()
            .HasForeignKey(r => r.WorkerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}