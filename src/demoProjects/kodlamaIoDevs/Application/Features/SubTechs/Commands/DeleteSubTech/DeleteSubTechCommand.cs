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

namespace Application.Features.SubTechs.Commands.DeleteSubTech
{
    public class DeleteSubTechCommand:IRequest<DeletedSubTechDto>
    {

        public string Id { get; set; }

        public class DeleteSubTechCommandHandler : IRequestHandler<DeleteSubTechCommand, DeletedSubTechDto>
        {
            ISubTechRepository _subTechRepository;
            IMapper _mapper;

            public DeleteSubTechCommandHandler(ISubTechRepository subTechRepository, IMapper mapper)
            {
                _subTechRepository = subTechRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSubTechDto> Handle(DeleteSubTechCommand request, CancellationToken cancellationToken)

            {
                SubTech mappedSubTech = _mapper.Map<SubTech>(request);
                SubTech deletedSubTech = await _subTechRepository.DeleteAsync(mappedSubTech);
                DeletedSubTechDto deletedSubTechDto = _mapper.Map<DeletedSubTechDto>(deletedSubTech);
                return deletedSubTechDto;
            }
        }
    }

}