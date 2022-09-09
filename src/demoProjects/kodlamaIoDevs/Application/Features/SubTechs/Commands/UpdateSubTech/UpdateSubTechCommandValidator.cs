using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Commands.UpdateSubTech
{
    public class UpdateSubTechCommandValidator : AbstractValidator<UpdateSubTechCommand>
    {
        public UpdateSubTechCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
