using Application.Features.DevelopmentLanguages.Commands.CreateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Commands.UpdateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Dtos;
using Application.Features.DevelopmentLanguages.Models;
using Application.Features.DevelopmentLanguages.Queries;
using AutoMapper;
using Core.Persistence.Paging;
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

            CreateMap<DevelopmentLanguage, DeletedDevelopmentLanguageDto>().ReverseMap();
            CreateMap<DevelopmentLanguage, DeleteDevelopmentLanguageCommand>().ReverseMap();

            CreateMap<DevelopmentLanguage, UpdatedDevelopmentLanguageDto>().ReverseMap();
            CreateMap<DevelopmentLanguage, UpdateDevelopmentLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<DevelopmentLanguage>, DevelopmentLanguageListModel>().ReverseMap();
            CreateMap<DevelopmentLanguage,DevelopmentLanguageListDto>().ReverseMap();

        }
    }
}
