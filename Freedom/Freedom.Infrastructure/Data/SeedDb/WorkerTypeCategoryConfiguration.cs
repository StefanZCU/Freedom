using Freedom.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freedom.Infrastructure.Data.SeedDb;

public class WorkerTypeCategoryConfiguration : IEntityTypeConfiguration<WorkerTypeCategory>
{
    public void Configure(EntityTypeBuilder<WorkerTypeCategory> builder)
    {
        var data = new SeedData();

        builder.HasData(data.PlumberCategory, data.ElectricianCategory, data.GardenerCategory, data.CleanerCategory);
    }
}