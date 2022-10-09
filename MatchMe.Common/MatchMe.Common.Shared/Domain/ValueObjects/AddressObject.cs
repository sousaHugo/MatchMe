using FluentValidation;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record AddressObject
    {
        private AddressObjectValidator _validator = new();
        private AddressObject()
        {
            var validationResult = _validator.Validate(this);
            if(!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(AddressObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public AddressObject(string Street, string City, string State, string PostCode, string Country)
            : base()
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
}
