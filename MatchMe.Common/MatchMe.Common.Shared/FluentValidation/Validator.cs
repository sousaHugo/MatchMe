using FluentValidation;
using MatchMe.Common.Shared.Domain.ValueObjects;
namespace MatchMe.Common.Shared.FluentValidation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        public Validator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
