using Application.Features.DevelopmentLanguages.Commands.CreateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Dtos;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentLanguages.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DevelopmentLanguage, CreatedDevelopmentLanguageDto>().ReverseMap();
            CreateMap<DevelopmentLanguage, CreateDevelopmentLanguageCommand>().ReverseMap();

        }
    }
}
