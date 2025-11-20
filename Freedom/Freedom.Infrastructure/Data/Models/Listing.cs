using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Freedom.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Comment("Listings")]
public class Listing
{
    [Key]
    [Comment("Listing ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(ListingTitleMaxLength)]
    [Comment("Listing title")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(ListingDescriptionMaxLength)]
    [Comment("Listing description")]
    public required string Description { get; set; }

    [Required]
    [MaxLength(ListingLocationAddressMaxLength)]
    [Comment("Listing location address")]
    public required string LocationAddress { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Comment("Listing budget")]
    public decimal Budget { get; set; }

    public ListingStatus ListingStatus { get; set; } = ListingStatus.Active;

    public bool IsApproved { get; set; } = false;

    [Required]
    [Comment("Worker type needed for job listing")]
    public int WorkerTypeCategoryId { get; set; }

    [ForeignKey(nameof(WorkerTypeCategoryId))]
    public WorkerTypeCategory WorkerTypeCategory { get; set; } = null!;

    [Required]
    [Comment("Listing uploader ID")]
    public required string UploaderId { get; set; }

    [ForeignKey(nameof(UploaderId))]
    public IdentityUser Uploader { get; set; } = null!;

    [Comment("Worker ID")]
    public int? WorkerId { get; set; }

    [ForeignKey(nameof(WorkerId))]
    public Worker? Worker { get; set; }
}