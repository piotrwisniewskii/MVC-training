using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoVallidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoVallidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(d => d.Description)
                .NotEmpty();

            RuleFor(pn=>pn.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
