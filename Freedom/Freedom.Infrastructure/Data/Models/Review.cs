using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Index(nameof(ListingId), IsUnique = true)]
[Comment("Worker Reviews")]
public class Review
{
    [Key] [Comment("Review ID")] public int Id { get; set; }

    [Required]
    [Comment("Review Rating")]
    public int Rating { get; set; }

    [Required]
    [Comment("Review Comment")]
    [MaxLength(ReviewCommentMaxLength)]
    public required string Comment { get; set; }

    [Required]
    [Comment("Review Creation Date")]
    public DateTime ReviewCreatedDateUtc { get; set; } = DateTime.UtcNow;

    [Required]
    [Comment("Reviewer User ID")]
    public required string ReviewerId { get; set; }

    [ForeignKey(nameof(ReviewerId))]
    public ApplicationUser Reviewer { get; set; } = null!;

    [Required]
    [Comment("Worker ID")]
    public int WorkerId { get; set; }

    [ForeignKey(nameof(WorkerId))]
    public Worker Worker { get; set; } = null!;
    
    [Required] 
    [Comment("Listing ID")] 
    public int ListingId { get; set; }

    [ForeignKey(nameof(ListingId))] 
    public Listing Listing { get; set; } = null!;

    public bool IsReviewApprovedByAdmin { get; set; } = false;
}