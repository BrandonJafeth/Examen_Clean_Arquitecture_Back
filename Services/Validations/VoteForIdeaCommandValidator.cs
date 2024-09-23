using FluentValidation;
using Services.Commands.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class VoteForIdeaCommandValidator : AbstractValidator<VoteForIdeaCommand>
    {
        public VoteForIdeaCommandValidator()
        {
            RuleFor(x => x.IdeaId)
                .GreaterThan(0)
                .WithMessage("El ID de la idea debe ser mayor que 0.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("El nombre del usuario es obligatorio.");
        }
    }
}