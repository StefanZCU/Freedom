using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Freedom.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Comment("Job Listings")]
public class Listing
{
    [Key]
    [Comment("Listing ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(ListingTitleMaxLength)]
    [Comment("Job Title")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(ListingDescriptionMaxLength)]
    [Comment("Job Description")]
    public required string Description { get; set; }
    
    [Required]
    [MaxLength(ListingLocationAddressMaxLength)]
    [Comment("Job Location Address")]
    public required string LocationAddress { get; set; }
    
    [Required]
    [Comment("Amount of Pay for Job")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountOfPay { get; set; }
    
    [Required]
    [Comment("Status of Job Listing")]
    public ListingStatus ListingStatus { get; set; } = ListingStatus.Draft;
    
    [Required]
    [Comment("User ID of uploader")]
    public required string UploaderId { get; set; }

    [ForeignKey(nameof(UploaderId))]
    public ApplicationUser Uploader { get; set; } = null!;
    
    [Comment("Worker ID")]
    public int? WorkerId { get; set; }
    
    [ForeignKey(nameof(WorkerId))]
    public Worker? Worker { get; set; }
    
    [Required]
    [Comment("Type of Worker Needed for Job")]
    public int WorkerTypeCategoryId { get; set; }

    [ForeignKey(nameof(WorkerTypeCategoryId))]
    public WorkerTypeCategory WorkerTypeCategory { get; set; } = null!;
    
    [Required]
    [Comment("Job Listing Creation Date")]
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    
    [Required]
    [Comment("Job Listing Expiration Date")]
    public DateTime ExpirationDateUtc { get; set; }
    
    [Comment("Job Listing Claim Date")]
    public DateTime? ClaimedAtUtc { get; set; }
    
    [Comment("Job Listing Completion Date")]
    public DateTime? CompletedAtUtc { get; set; }
    
    
}