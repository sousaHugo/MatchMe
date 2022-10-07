using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record DateOfBirthObject
    {
        public DateOfBirthObject(DateTime Value) 
        {
            this.Value = Value;
        }
        public DateTime Value { get; }
      
        public static implicit operator DateTime(DateOfBirthObject TextObject) => TextObject.Value;

        public static implicit operator DateOfBirthObject(DateTime Value) => new(Value);
    }
    public class DateOfBirthObjectValidator : AbstractValidator<DateOfBirthObject>
    {
        public DateOfBirthObjectValidator()
        {
            RuleFor(r => r.Value).NotEmpty().NotNull();
            RuleFor(r => r.Value).LessThan(DateTime.Today);
        }
    }
}
