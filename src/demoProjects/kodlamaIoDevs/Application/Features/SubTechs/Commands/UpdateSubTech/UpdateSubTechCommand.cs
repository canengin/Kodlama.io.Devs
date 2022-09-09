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

namespace Application.Features.SubTechs.Commands.UpdateSubTech
{
    public class UpdateSubTechCommand : IRequest<UpdatedSubTechDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ImageUrl { get; set; }
        public class UpdateSubTechCommandCommandHandler : IRequestHandler<UpdateSubTechCommand, UpdatedSubTechDto>
        {
            private readonly ISubTechRepository _subTechRepository;
            private readonly IMapper _mapper;

            public UpdateSubTechCommandCommandHandler(ISubTechRepository subTechRepository, IMapper mapper)
            {
                _subTechRepository = subTechRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSubTechDto> Handle(UpdateSubTechCommand request, CancellationToken cancellationToken)
            {
                SubTech mappedSubTech = _mapper.Map<SubTech>(request);
                SubTech updatedSubTech = await _subTechRepository.UpdateAsync(mappedSubTech);
                UpdatedSubTechDto updatedSubTechDto = _mapper.Map<UpdatedSubTechDto>(updatedSubTech);
                return updatedSubTechDto;
            }



        }
    }
}
