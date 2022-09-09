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

namespace Application.Features.SubTechs.Queries.GetByIdSubTech
{
    public class GetByIdSubTechQuery : IRequest<SubTechGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdSubTechQueryHandler : IRequestHandler<GetByIdSubTechQuery, SubTechGetByIdDto>
        {
            private readonly ISubTechRepository _subTechRepository;
            private readonly IMapper _mapper;

            public GetByIdSubTechQueryHandler(ISubTechRepository subTechRepository, IMapper mapper)
            {
                _subTechRepository = subTechRepository;
                _mapper = mapper;
                
            }

            public async Task<SubTechGetByIdDto> Handle(GetByIdSubTechQuery request, CancellationToken cancellationToken)
            {

                SubTech subTech = await _subTechRepository.GetAsync(st => st.Id == request.Id);
                SubTechGetByIdDto subTechGetByIdDto = _mapper.Map<SubTechGetByIdDto>(subTech);
                return subTechGetByIdDto;
            }
        }
    }
}
