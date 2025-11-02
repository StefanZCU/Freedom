using System.ComponentModel.DataAnnotations;
using Freedom.Core.Models.Worker;
using static Freedom.Infrastructure.Constants.DataConstants;
using static Freedom.Core.Constants.ErrorConstants;

namespace Freedom.Core.Models.Listing;

public class ListingFormModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(
        maximumLength: ListingTitleMaxLength,
        MinimumLength = ListingTitleMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    public required string Title { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(
        maximumLength: ListingDescriptionMaxLength,
        MinimumLength = ListingDescriptionMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    public required string Description { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(
        maximumLength: ListingLocationAddressMaxLength,
        MinimumLength = ListingLocationAddressMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    [Display(Name = "Location Address")]
    public required string LocationAddress { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [Range(typeof(decimal),
        ListingBudgetMinPrice,
        ListingBudgetMaxPrice,
        ConvertValueInInvariantCulture = true,
        ErrorMessage = InvalidBudgetError)]
    public decimal Budget { get; set; }
    
    [Display(Name = "Worker type")]
    public int WorkerTypeCategoryId { get; set; }

    public IEnumerable<WorkerTypeCategoryServiceModel> WorkerTypeCategories { get; set; } = new List<WorkerTypeCategoryServiceModel>();
}