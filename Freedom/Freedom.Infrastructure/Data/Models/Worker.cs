using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Freedom.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Index(nameof(PhoneNumber), IsUnique = true)]
[Comment("Workers")]
public class Worker
{
    [Key]
    [Comment("Worker ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(WorkerPhoneNumberMaxLength)]
    [Comment("Worker phone number")]
    public required string PhoneNumber { get; set; }

    [Required]
    [Comment("Worker's years of experience")]
    public int YearsOfExperience { get; set; }
    
    [Required]
    [Comment("Worker's rating")]
    public bool IsApproved { get; set; } = false;
    
    [Required]
    [Comment("Worker status")]
    public WorkerStatus WorkerStatus { get; set; } = WorkerStatus.Pending;

    [Required]
    [Comment("Worker type category ID")]
    public int WorkerTypeCategoryId { get; set; }

    [ForeignKey(nameof(WorkerTypeCategoryId))]
    public WorkerTypeCategory WorkerTypeCategory { get; set; } = null!;

    [Required]
    [Comment("Worker user ID")]
    public required string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;
}