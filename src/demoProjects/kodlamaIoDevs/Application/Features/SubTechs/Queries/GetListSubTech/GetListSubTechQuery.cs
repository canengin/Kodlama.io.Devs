using Application.Features.SubTechs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Queries.GetListSubTech
{
    public class GetListSubTechQuery : IRequest<SubTechListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListSubTechQueryHandler : IRequestHandler<GetListSubTechQuery, SubTechListModel>
        {
            private readonly ISubTechRepository _subTechRepository;
            private readonly IMapper _mapper;

            public GetListSubTechQueryHandler(ISubTechRepository subTechRepository, IMapper mapper)
            {
                _subTechRepository = subTechRepository;
                _mapper = mapper;
            }

            public async Task<SubTechListModel> Handle(GetListSubTechQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SubTech> subTechs = await _subTechRepository.GetListAsync(include:
                                                                                   m => m.Include(c => c.ProgrammingLanguage),
                                                                                   index: request.PageRequest.Page,
                                                                                   size: request.PageRequest.PageSize
                                                                                   );
                SubTechListModel mappedSubTechs = _mapper.Map<SubTechListModel>(subTechs);
                return mappedSubTechs;


            }
        }
    }
}
