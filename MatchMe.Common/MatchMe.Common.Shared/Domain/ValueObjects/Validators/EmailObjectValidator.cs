using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class EmailObjectValidator : Validator<EmailObject>
    {
        public EmailObjectValidator()
        {
            RuleFor(r => r.Value).EmailAddress();
        }
    }
}
