using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Commands.DeleteSubTech
{
    public class DeleteSubTechCommandValidator : AbstractValidator<DeleteSubTechCommand>
    {
        public DeleteSubTechCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
