using FluentValidation;
using FluentValidation.Results;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record EmailObject
    {
        public EmailObject(string Value)
        {
            this.Value = Value;
        }
        public string Value { get; }
      
        public static implicit operator string(EmailObject TextObject) => TextObject.Value;

        public static implicit operator EmailObject(string Value) => new(Value);
    }
    public class EmailObjectValidator : AbstractValidator<EmailObject>
    {
        public EmailObjectValidator()
        {
            RuleFor(r => r.Value).NotEmpty().NotNull();
            RuleFor(r => r.Value).EmailAddress();
        }
    }
}
