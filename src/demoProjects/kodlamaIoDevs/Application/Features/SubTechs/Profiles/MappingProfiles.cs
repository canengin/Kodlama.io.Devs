using Application.Features.SubTechs.Commands.CreateSubTech;
using Application.Features.SubTechs.Commands.DeleteSubTech;
using Application.Features.SubTechs.Commands.UpdateSubTech;
using Application.Features.SubTechs.Dtos;
using Application.Features.SubTechs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SubTech, CreatedSubTechDto>().ReverseMap();
            CreateMap<SubTech, CreateSubTechCommand>().ReverseMap();

            CreateMap<SubTech, DeletedSubTechDto>().ReverseMap();
            CreateMap<SubTech, DeleteSubTechCommand>().ReverseMap();

            CreateMap<SubTech, UpdatedSubTechDto>().ReverseMap();
            CreateMap<SubTech, UpdateSubTechCommand>().ReverseMap();


            CreateMap<IPaginate<SubTech>, SubTechListModel>().ReverseMap();
            CreateMap<SubTech, SubTechListDto>()
                     .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                     .ReverseMap();

            CreateMap<SubTech, SubTechGetByIdDto>().ReverseMap();


        }
    }
}
