using Freedom.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static Freedom.Infrastructure.Data.SeedDb.SeedIds;
using Freedom.Infrastructure.Enums; // for ListingStatus, adjust namespace if needed

namespace Freedom.Infrastructure.Data.SeedDb;

public class SeedData
{
    // Users
    public IdentityUser GuestUser1 { get; set; }
    public IdentityUser GuestUser2 { get; set; }
    public IdentityUser GuestUser3 { get; set; }

    public IdentityUser PlumberUser { get; set; }
    public IdentityUser ElectricianUser { get; set; }
    public IdentityUser GardenerUser { get; set; }
    public IdentityUser CleanerUser { get; set; }

    // Workers
    public Worker PlumberWorker { get; set; }
    public Worker ElectricianWorker { get; set; }
    public Worker GardenerWorker { get; set; }
    public Worker CleanerWorker { get; set; }

    // Categories
    public WorkerTypeCategory PlumberCategory { get; set; }
    public WorkerTypeCategory ElectricianCategory { get; set; }
    public WorkerTypeCategory GardenerCategory { get; set; }
    public WorkerTypeCategory CleanerCategory { get; set; }

    // Listings
    public Listing PlumbingCompleteListing { get; set; }
    public Listing ElectricInspectionPendingListing { get; set; }
    public Listing GardeningAssignedListing { get; set; }
    public Listing CleaningCompletedListing { get; set; }
    public Listing PlumbingAssignedListing { get; set; }
    public Listing ElectricRejectedListing { get; set; }

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

        GuestUser1 = new IdentityUser
        {
            Id = GuestUser1Id.ToString(),
            UserName = "guest1@gmail.com",
            NormalizedUserName = "GUEST1@GMAIL.COM",
            Email = "guest1@gmail.com",
            NormalizedEmail = "GUEST1@GMAIL.COM",
            EmailConfirmed = true
        };
        GuestUser1.PasswordHash = hasher.HashPassword(GuestUser1, "guest123");

        GuestUser2 = new IdentityUser
        {
            Id = GuestUser2Id.ToString(),
            UserName = "guest2@gmail.com",
            NormalizedUserName = "GUEST2@GMAIL.COM",
            Email = "guest2@gmail.com",
            NormalizedEmail = "GUEST2@GMAIL.COM",
            EmailConfirmed = true
        };
        GuestUser2.PasswordHash = hasher.HashPassword(GuestUser2, "guest123");

        GuestUser3 = new IdentityUser
        {
            Id = GuestUser3Id.ToString(),
            UserName = "guest3@gmail.com",
            NormalizedUserName = "GUEST3@GMAIL.COM",
            Email = "guest3@gmail.com",
            NormalizedEmail = "GUEST3@GMAIL.COM",
            EmailConfirmed = true
        };
        GuestUser3.PasswordHash = hasher.HashPassword(GuestUser3, "guest123");

        PlumberUser = new IdentityUser
        {
            Id = PlumberUserId.ToString(),
            UserName = "plumber.worker@gmail.com",
            NormalizedUserName = "PLUMBER.WORKER@GMAIL.COM",
            Email = "plumber.worker@gmail.com",
            NormalizedEmail = "PLUMBER.WORKER@GMAIL.COM",
            EmailConfirmed = true
        };
        PlumberUser.PasswordHash = hasher.HashPassword(PlumberUser, "worker123");

        ElectricianUser = new IdentityUser
        {
            Id = ElectricianUserId.ToString(),
            UserName = "electric.worker@gmail.com",
            NormalizedUserName = "ELECTRIC.WORKER@GMAIL.COM",
            Email = "electric.worker@gmail.com",
            NormalizedEmail = "ELECTRIC.WORKER@GMAIL.COM",
            EmailConfirmed = true
        };
        ElectricianUser.PasswordHash = hasher.HashPassword(ElectricianUser, "worker123");

        GardenerUser = new IdentityUser
        {
            Id = GardenerUserId.ToString(),
            UserName = "gardener.worker@gmail.com",
            NormalizedUserName = "GARDENER.WORKER@GMAIL.COM",
            Email = "gardener.worker@gmail.com",
            NormalizedEmail = "GARDENER.WORKER@GMAIL.COM",
            EmailConfirmed = true
        };
        GardenerUser.PasswordHash = hasher.HashPassword(GardenerUser, "worker123");

        CleanerUser = new IdentityUser
        {
            Id = CleanerUserId.ToString(),
            UserName = "cleaner.worker@gmail.com",
            NormalizedUserName = "CLEANER.WORKER@GMAIL.COM",
            Email = "cleaner.worker@gmail.com",
            NormalizedEmail = "CLEANER.WORKER@GMAIL.COM",
            EmailConfirmed = true
        };
        CleanerUser.PasswordHash = hasher.HashPassword(CleanerUser, "worker123");
    }

    private void SeedWorkerTypeCategories()
    {
        PlumberCategory = new WorkerTypeCategory
        {
            Id = 1,
            Name = "Plumber"
        };

        ElectricianCategory = new WorkerTypeCategory
        {
            Id = 2,
            Name = "Electrician"
        };

        GardenerCategory = new WorkerTypeCategory
        {
            Id = 3,
            Name = "Gardener"
        };

        CleanerCategory = new WorkerTypeCategory
        {
            Id = 4,
            Name = "Cleaner"
        };
    }

    private void SeedWorkers()
    {

        PlumberWorker = new Worker
        {
            Id = 1,
            PhoneNumber = "+359888111111",
            UserId = PlumberUser.Id,
            YearsOfExperience = 12,
            WorkerTypeCategoryId = PlumberCategory.Id,
            WorkerStatus = WorkerStatus.Active
        };

        ElectricianWorker = new Worker
        {
            Id = 2,
            PhoneNumber = "+359888222222",
            UserId = ElectricianUser.Id,
            YearsOfExperience = 8,
            WorkerTypeCategoryId = ElectricianCategory.Id,
            WorkerStatus = WorkerStatus.Rejected
        };

        GardenerWorker = new Worker
        {
            Id = 3,
            PhoneNumber = "+359888333333",
            UserId = GardenerUser.Id,
            YearsOfExperience = 5,
            WorkerTypeCategoryId = GardenerCategory.Id,
            WorkerStatus = WorkerStatus.Pending
        };

        CleanerWorker = new Worker
        {
            Id = 4,
            PhoneNumber = "+359888444444",
            UserId = CleanerUser.Id,
            YearsOfExperience = 2,
            WorkerTypeCategoryId = CleanerCategory.Id,
            WorkerStatus = WorkerStatus.Active
        };
    }

    private void SeedListings()
    {
        PlumbingCompleteListing = new Listing
        {
            Id = 1,
            Title = "Plumber needed ASAP for major leak",
            Description = "Emergency plumbing work required for burst pipe in apartment. Must arrive within 2 hours.",
            LocationAddress = "ul. \"Tsar Osvoboditel\" 13, Sofia, Bulgaria - 1000",
            Budget = 1000.00M,
            WorkerTypeCategoryId = PlumberCategory.Id,
            UploaderId = GuestUser1.Id,
            WorkerId = PlumberWorker.Id,
            ListingStatus = ListingStatus.Completed
        };

        ElectricInspectionPendingListing = new Listing
        {
            Id = 2,
            Title = "Electrical inspection for office space",
            Description = "Need a certified electrician to inspect wiring before renovation. Not urgent yet, still planning scope.",
            LocationAddress = "bul. \"Vitosha\" 42, Sofia, Bulgaria - 1000",
            Budget = 1500.00M,
            WorkerTypeCategoryId = ElectricianCategory.Id,
            UploaderId = GuestUser2.Id,
            WorkerId = null,
            ListingStatus = ListingStatus.Pending
        };

        GardeningAssignedListing = new Listing
        {
            Id = 3,
            Title = "Ongoing garden maintenance for family house",
            Description = "Weekly maintenance: trimming hedges, mowing lawn, seasonal planting. Long-term opportunity.",
            LocationAddress = "ul. \"Shipka\" 7, Plovdiv, Bulgaria - 4000",
            Budget = 600.00M,
            WorkerTypeCategoryId = GardenerCategory.Id,
            UploaderId = GuestUser1.Id,
            WorkerId = null,
            ListingStatus = ListingStatus.Assigned
        };

        CleaningCompletedListing = new Listing
        {
            Id = 4,
            Title = "One-time deep cleaning after renovation",
            Description = "Apartment just renovated, need full deep clean including windows, balcony, and furniture dust removal.",
            LocationAddress = "ul. \"Graf Ignatiev\" 19, Sofia, Bulgaria - 1000",
            Budget = 400.00M,
            WorkerTypeCategoryId = CleanerCategory.Id,
            UploaderId = GuestUser3.Id,
            WorkerId = CleanerWorker.Id,
            ListingStatus = ListingStatus.Completed
        };

        PlumbingAssignedListing = new Listing
        {
            Id = 5,
            Title = "Bathroom fixture installation",
            Description = "Install new sink, toilet, and shower fixtures. Materials already purchased.",
            LocationAddress = "ul. \"Patriarh Evtimiy\" 5, Sofia, Bulgaria - 1000",
            Budget = 800.00M,
            WorkerTypeCategoryId = PlumberCategory.Id,
            UploaderId = GuestUser2.Id,
            WorkerId = PlumberWorker.Id,
            ListingStatus = ListingStatus.Assigned
        };

        ElectricRejectedListing = new Listing
        {
            Id = 6,
            Title = "Lighting upgrade for small shop",
            Description = "Replace old halogen lights with LED spots and improve overall lighting layout.",
            LocationAddress = "ul. \"Rakovski\" 102, Sofia, Bulgaria - 1000",
            Budget = 900.00M,
            WorkerTypeCategoryId = ElectricianCategory.Id,
            UploaderId = GuestUser3.Id,
            WorkerId = null,
            ListingStatus = ListingStatus.Rejected
        };
    }
}