using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Commands.CreateSubTech
{
    public class CreateSubTechCommandValidator : AbstractValidator<CreateSubTechCommand>
    {
        public CreateSubTechCommandValidator()
        {
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ImageUrl).NotEmpty();
        }
    }
}
