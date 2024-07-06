using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nazwa jest wymagana!")
                .Length(2, 20).WithMessage("Nazwa musi zawierać od 2 do 20 znaków!");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Opis jest wymagany!");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Numer telefonu musi zawierac od 8 do 14 cyfr")
                .MaximumLength(14).WithMessage("Numer telefonu musi zawierac od 8 do 14 cyfr");
        }
    }
}
