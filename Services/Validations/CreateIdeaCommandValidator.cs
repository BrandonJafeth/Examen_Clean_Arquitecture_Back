using FluentValidation;
using Services.Commands.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class CreateIdeaCommandValidator : AbstractValidator<CreateIdeaCommand>
    {
        public CreateIdeaCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("El título es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El título no puede exceder los 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripción es obligatoria.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .WithMessage("El nombre del creador es obligatorio.");
        }
    }
}
