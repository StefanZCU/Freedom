using System.ComponentModel.DataAnnotations;

namespace Freedom.Core.Models.Worker;
using static Freedom.Infrastructure.Constants.DataConstants;
using static Freedom.Core.Constants.ErrorConstants;

public class BecomeWorkerFormModel
{
    [Required(ErrorMessage = RequiredFieldWorkerError)]
    [StringLength(
        maximumLength: WorkerPhoneNumberMaxLength,
        MinimumLength = WorkerPhoneNumberMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    [Display(Name = "Phone number")]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessage = RequiredFieldWorkerError)]
    [Range(0, 60, ConvertValueInInvariantCulture = true, ErrorMessage = InvalidYearsOfExperienceError)]
    public int YearsOfExperience { get; set; }

    [Required(ErrorMessage = RequiredFieldWorkerError)]
    [Display(Name = "Worker type")]
    public int WorkerTypeCategoryId { get; set; }

    public IEnumerable<WorkerTypeCategoryServiceModel> WorkerTypeCategories { get; set; } = new List<WorkerTypeCategoryServiceModel>();
}