using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)           //add icarworkshoprepository to the constructor for validation purposes .custom will be have access to the repository
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nazwa jest wymagana!")
                .Length(2, 20).WithMessage("Nazwa musi zawierać od 2 do 20 znaków!")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} - Warsztat o podanej nazwie już istnieje!");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Opis jest wymagany!");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Numer telefonu musi zawierac od 8 do 12 cyfr")
                .MaximumLength(12).WithMessage("Numer telefonu musi zawierac od 8 do 12 cyfr");
        }
    }
}
