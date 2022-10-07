using FluentValidation;
using FluentValidation.Validators;

namespace MatchMe.Common.Shared.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> RuleBuilder)
        {
            return RuleBuilder.SetValidator(new NotNullValidator<T, TProperty>())
                .SetValidator(new NotEmptyValidator<T, TProperty>());
        }
    }
}
