using MatchMe.Candidates.Application.Dto.Candidates.Validators;
using MatchMe.Common.Shared.Dtos;
using MatchMe.Common.Shared.Helpers;
using System.Diagnostics;

namespace MatchMe.Candidates.Application.Dto.Candidates.Extensions
{
    public static class CandidateValidatorExtension
    {
        public static ValidationDto Validate(this CandidateCreateDto Dto)
        {
            var validator = new CandidateCreateDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }

        public static ValidationDto Validate(this CandidateCreateWithDetailsDto Dto)
        {
            var validator = new CandidateCreateWithDetailsDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }

        public static ValidationDto Validate(this CandidateUpdateWithDetailsDto Dto)
        {
            var validator = new CandidateUpdateWithDetailsDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }
    }
}
