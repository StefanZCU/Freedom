using Freedom.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freedom.Infrastructure.Data.SeedDb;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        var data = new SeedData();

        builder.HasData(data.PlumbingCompleteListing, data.ElectricInspectionPendingListing, data.GardeningAssignedListing, data.CleaningCompletedListing, data.PlumbingAssignedListing, data.ElectricRejectedListing);
    }
}