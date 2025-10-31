using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Index(nameof(PhoneNumber), IsUnique = true)]
[Comment("Users")]
public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(UserFirstNameMaxLength)]
    [PersonalData]
    [Comment("User first name")]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(UserLastNameMaxLength)]
    [PersonalData]
    [Comment("User last name")]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(UserPhoneNumberMaxLength)]
    [PersonalData]
    [Comment("User phone number")]
    public required string PhoneNumber { get; set; }

    public Worker? Worker { get; set; }
}