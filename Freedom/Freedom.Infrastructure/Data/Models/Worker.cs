using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Infrastructure.Data.Models;

[Comment("Workers")]
public class Worker
{
    [Key]
    [Comment("Worker ID")]
    public int Id { get; set; }

    [Required]
    [Comment("Years of Experience")]
    public int YearsOfExperience { get; set; }
    
    [Comment("Reviews of Worker")]
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    [Comment("Is Worker Approved by Admin")]
    public bool IsApprovedWorkerByAdmin { get; set; } = false;

    [Required]
    [Comment("Type of Worker")]
    public int WorkerTypeCategoryId { get; set; }

    [ForeignKey(nameof(WorkerTypeCategoryId))]
    public WorkerTypeCategory WorkerTypeCategory { get; set; } = null!;
    
    [Required]
    [Comment("User ID of worker")]
    public required string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
    
    [NotMapped]
    public double? AverageRating => Reviews.Count != 0
        ? Reviews.Average(r => r.Rating)
        : null;
}