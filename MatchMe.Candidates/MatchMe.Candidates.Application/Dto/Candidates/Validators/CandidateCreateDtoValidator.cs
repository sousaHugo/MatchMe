using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.Candidates.Validators
{
    public class CandidateCreateDtoValidator : Validator<CandidateCreateDto>
    {
        public CandidateCreateDtoValidator()
            : base()
        {
            RuleFor(x => x).SetValidator(new CandidateBaseDtoValidator());
        }

    }
}
