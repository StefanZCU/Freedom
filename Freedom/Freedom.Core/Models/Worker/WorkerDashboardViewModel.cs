using System.ComponentModel.DataAnnotations;
using Freedom.Infrastructure.Enums;

namespace Freedom.Core.Models.Worker;

public class WorkerDashboardViewModel
{
    public int WorkerId { get; set; }

    [Display(Name = "Email address")]
    public required string WorkerEmail { get; set; }
    
    [Display(Name = "Phone number")]
    public required string PhoneNumber { get; set; }

    [Display(Name = "Years of experience")]
    public int YearsOfExperience { get; set; }

    [Display(Name = "Worker status")]
    public WorkerStatus WorkerStatus { get; set; }

    
    public int TotalListings { get; set; }

    public int TotalAssignedListings { get; set; }

    public int TotalCompletedListings { get; set; }


    public IEnumerable<WorkerListingViewModel> Listings { get; set; } = [];
}