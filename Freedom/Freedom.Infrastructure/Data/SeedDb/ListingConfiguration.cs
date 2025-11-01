using Freedom.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freedom.Infrastructure.Data.SeedDb;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        var data = new SeedData();

        builder.HasData(data.PlumbingListing, data.ElectricListing, data.GardeningListing);
    }
}