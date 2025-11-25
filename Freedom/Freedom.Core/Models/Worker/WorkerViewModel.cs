namespace Freedom.Core.Models.Worker;

public class WorkerViewModel
{
    public int Id { get; set; }

    public required string PhoneNumber { get; set; }

    public int YearsOfExperience { get; set; }

    public required string WorkerTypeCategory { get; set; } 
}