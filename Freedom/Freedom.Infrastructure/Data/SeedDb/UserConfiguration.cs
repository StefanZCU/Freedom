using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freedom.Infrastructure.Data.SeedDb;

public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        var data = new SeedData();
        
        builder.HasData(data.GuestUser1, data.GuestUser2, data.GuestUser3, data.PlumberUser, data.ElectricianUser, data.GardenerUser, data.CleanerUser);
    }
}