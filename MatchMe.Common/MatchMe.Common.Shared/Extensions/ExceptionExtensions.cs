using FluentValidation.Results;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Common.Shared.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<DomainEntityValidationErrorException> ToDomainEntityValidationException(this IEnumerable<string> ValidationErrors)
        {
            return ValidationErrors.Select(ve => new DomainEntityValidationErrorException(ve));
        }
        public static IEnumerable<DomainEntityValidationErrorException> ToDomainEntityValidationException(this ValidationResult ValidationResult)
        {
            return ValidationResult.Errors.Select(ve => new DomainEntityValidationErrorException($"{ve.PropertyName};{ve.ErrorMessage}"));
        }
    }
}
