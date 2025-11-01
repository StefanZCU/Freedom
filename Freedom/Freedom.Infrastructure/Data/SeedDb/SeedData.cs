using Freedom.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static Freedom.Infrastructure.Data.SeedDb.SeedIds;

namespace Freedom.Infrastructure.Data.SeedDb;

public class SeedData
{
    public IdentityUser GuestUser { get; set; }

    public IdentityUser WorkerUser { get; set; }

    public Worker Worker { get; set; }

    public WorkerTypeCategory PlumberCategory { get; set; }

    public WorkerTypeCategory ElectricianCategory { get; set; }

    public WorkerTypeCategory GardenerCategory { get; set; }

    public WorkerTypeCategory CleanerCategory { get; set; }

    public Listing PlumbingListing { get; set; }

    public Listing ElectricListing { get; set; }

    public Listing GardeningListing { get; set; }

    public SeedData()
    {
        SeedUsers();
        SeedWorkerTypeCategories();
        SeedWorkers();
        SeedListings();
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        GuestUser = new IdentityUser()
        {
            Id = GuestUserId.ToString(),
            UserName = "Guest@gmail.com",
            NormalizedUserName = "GUEST@GMAIL.COM",
            Email = "Guest@gmail.com",
            NormalizedEmail = "GUEST@GMAIL.COM"
        };
        
        GuestUser.PasswordHash = 
            hasher.HashPassword(GuestUser, "guest123");

        WorkerUser = new IdentityUser()
        {
            Id = WorkerUserId.ToString(),
            UserName = "Worker@gmail.com",
            NormalizedUserName = "WORKER@GMAIL.COM",
            Email = "Worker@gmail.com",
            NormalizedEmail = "WORKER@GMAIL.COM"
        };
        
        WorkerUser.PasswordHash = 
            hasher.HashPassword(WorkerUser, "worker123");
    }

    private void SeedWorkerTypeCategories()
    {
        PlumberCategory = new WorkerTypeCategory()
        {
            Id = 1,
            Name = "Plumber"
        };

        ElectricianCategory = new WorkerTypeCategory()
        {
            Id = 2,
            Name = "Electrician"
        };

        GardenerCategory = new WorkerTypeCategory()
        {
            Id = 3,
            Name = "Gardener"
        };

        CleanerCategory = new WorkerTypeCategory()
        {
            Id = 4,
            Name = "Cleaner"
        };
    }

    private void SeedWorkers()
    {
        Worker = new Worker()
        {
            Id = 1,
            PhoneNumber = "+359888888888",
            UserId = WorkerUser.Id,
            YearsOfExperience = 10,
            WorkerTypeCategoryId = PlumberCategory.Id
        };
    }

    private void SeedListings()
    {
        PlumbingListing = new Listing()
        {
            Id = 1,
            Title = "Plumber needed ASAP",
            Description =
                "We are in need of a plumber with at least 5 years of experience to come fix the leak in our bathroom!",
            LocationAddress = "ul. \"Tsar Osvoboditel\" 13, Sofia, Bulgaria - 1000",
            Budget = 1000.00M,
            WorkerTypeCategoryId = PlumberCategory.Id,
            UploaderId = GuestUser.Id,
            WorkerId = Worker.Id
        };
        
        ElectricListing = new Listing()
        {
            Id = 2,
            Title = "Certified electrician required",
            Description = "Looking for a licensed electrician to inspect and repair faulty wiring in a residential apartment. Prior experience with panel upgrades is a plus.",
            LocationAddress = "bul. \"Vitosha\" 42, Sofia, Bulgaria - 1000",
            Budget = 1200.00M,
            WorkerTypeCategoryId = ElectricianCategory.Id,
            UploaderId = GuestUser.Id
        };

        GardeningListing = new Listing()
        {
            Id = 3,
            Title = "Gardener needed for yard maintenance",
            Description = "Seeking a reliable gardener to trim hedges, mow the lawn, and refresh flower beds. Long-term maintenance possible if work is solid.",
            LocationAddress = "ul. \"Shipka\" 7, Plovdiv, Bulgaria - 4000",
            Budget = 600.00M,
            WorkerTypeCategoryId = GardenerCategory.Id,
            UploaderId = GuestUser.Id
        };
    }
}