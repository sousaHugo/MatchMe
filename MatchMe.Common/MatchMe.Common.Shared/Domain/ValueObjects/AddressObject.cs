using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record AddressObject
    {
        public AddressObject(string Street, string City, string State, string PostCode, string Country)
        {
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.PostCode = PostCode;
            this.Country = Country;
        }

        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string PostCode { get; }
        public string Country { get; }

        public static AddressObject Create(string value)
        {
            var splitLocalization = value.Split(',');
            return new AddressObject(splitLocalization[0], splitLocalization[1], splitLocalization[2], splitLocalization[3], splitLocalization[4]);
        }

        public override string ToString()
            => $"{Street}, {PostCode}, {City}, {State}, {Country}";    
    }

    public class AddressObjectValidator : AbstractValidator<AddressObject>
    {
        public AddressObjectValidator()
        {
            RuleFor(r => r.Street).NotNull();
            RuleFor(r => r.City).NotNull();
            RuleFor(r => r.State).NotNull();
            RuleFor(r => r.PostCode).NotNull();
            RuleFor(r => r.Country).NotNull();
        }
    }
}
