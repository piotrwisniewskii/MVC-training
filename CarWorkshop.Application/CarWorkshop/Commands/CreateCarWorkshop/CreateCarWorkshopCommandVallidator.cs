using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandVallidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandVallidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("name should have at least 2 characters")
                .MaximumLength(20).WithMessage("name should maximum 20  characters")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure("There is already such CarWorkshop name");
                    }
                });

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Please eneter description");

            RuleFor(pn => pn.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
