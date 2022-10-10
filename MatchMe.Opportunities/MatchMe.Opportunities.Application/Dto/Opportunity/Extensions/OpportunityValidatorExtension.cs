using MatchMe.Common.Shared.Dtos;
using MatchMe.Common.Shared.Helpers;
using MatchMe.Opportunities.Application.Dto.Opportunity.Validators;
using System.Diagnostics;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Extensions
{
    public static class OpportunityValidatorExtension
    {
        public static ValidationDto Validate(this OpportunityCreateDto Dto)
        {
            var validator = new OpportunityCreateDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }

        public static ValidationDto Validate(this OpportunityCreateWithDetailsDto Dto)
        {
            var validator = new OpportunityCreateWithDetailsDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }
        public static ValidationDto Validate(this OpportunityUpdateWithDetailsDto Dto, long? Id = null)
        {
            var validator = new OpportunityUpdateWithDetailsDtoValidator(Id);
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }
    }
}
