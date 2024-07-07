using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarworkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Opis jest wymagany!");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Numer telefonu musi zawierac od 8 do 12 cyfr")
                .MaximumLength(12).WithMessage("Numer telefonu musi zawierac od 8 do 12 cyfr");
        }
    }
}
