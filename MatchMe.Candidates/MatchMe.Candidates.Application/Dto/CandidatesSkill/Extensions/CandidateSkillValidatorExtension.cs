using MatchMe.Candidates.Application.Dto.CandidatesSkill.Validators;
using MatchMe.Common.Shared.Dtos;
using MatchMe.Common.Shared.Helpers;
using System.Diagnostics;

namespace MatchMe.Candidates.Application.Dto.CandidatesSkill.Extensions
{
    public static class CandidateSkillValidatorExtension
    {
        public static ValidationDto Validate(this CandidateSkillCreateDto Dto)
        {
            var validator = new CandidateSkillBaseDtoValidator();
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }
        public static ValidationDto Validate(this CandidateSkillUpdateDto Dto, long Id)
        {
            var validator = new CandidateSkillUpdateDtoValidator(Id);
            var validationResult = validator.Validate(Dto);

            return new ValidationDto(validationResult.IsValid, new BadRequestReponseDto(Activity.Current?.Id, ValidationErrorHelper.ToDictionary(validationResult.Errors.Select(ve => $"{ve.PropertyName};{ve.ErrorMessage}"))));
        }
    }
}
