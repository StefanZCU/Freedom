using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Freedom.Infrastructure.Constants.DataConstants;

namespace Freedom.Infrastructure.Data.Models;

[Comment("Worker Type Categories")]
public class WorkerTypeCategory
{
    [Key]
    [Comment("Worker Type Category ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(WorkerTypeCategoryNameMaxLength)]
    [Comment("Worker Type Category Name")]
    public required string Name { get; set; }

    [Comment("Workers with this worker type category")]
    public IEnumerable<Worker> Workers { get; set; } = new List<Worker>();

    [Comment("Listings with this worker type category")]
    public IEnumerable<Listing> Listings { get; set; } = new List<Listing>();
}