using Application.Features.SubTechs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Commands.CreateSubTech
{
    public class CreateSubTechCommand : IRequest<CreatedSubTechDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateSubTechCommandHandler : IRequestHandler<CreateSubTechCommand, CreatedSubTechDto>
        {
            private readonly ISubTechRepository _subTechRepository;
            private readonly IMapper _mapper;

            public CreateSubTechCommandHandler(ISubTechRepository subTechRepository, IMapper mapper)
            {
                _subTechRepository = subTechRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSubTechDto> Handle(CreateSubTechCommand request, CancellationToken cancellationToken)

            {

                SubTech mappedSubTech = _mapper.Map<SubTech>(request);
                SubTech createdSubTech = await _subTechRepository.AddAsync(mappedSubTech);
                CreatedSubTechDto createdSubTechDto = _mapper.Map<CreatedSubTechDto>(createdSubTech);
                return createdSubTechDto;
            }
        }
    }
}
