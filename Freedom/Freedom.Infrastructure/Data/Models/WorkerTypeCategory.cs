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
    [MaxLength(CategoryNameMaxLength)]
    [Comment("Worker Type Category name")]
    public required string Name { get; set; }
}