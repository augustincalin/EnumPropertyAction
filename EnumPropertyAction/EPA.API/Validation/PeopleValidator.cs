using EPA.API.Model;
using FluentValidation;

namespace EPA.API.Validation
{
    public class PeopleValidator : AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(x => x.Gender)
                .NotEqual(GenderType.Undefined)
                .IsInEnum()
                .WithMessage("Invalid value for {PropertyName} property.");
        }
    }
}
