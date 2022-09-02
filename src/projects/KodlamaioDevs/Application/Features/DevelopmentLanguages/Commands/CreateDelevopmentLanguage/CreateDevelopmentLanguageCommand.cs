using Application.Features.DevelopmentLanguages.Dtos;
using Application.Features.DevelopmentLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentLanguages.Commands.CreateDelevopmentLanguage
{
    public  class CreateDevelopmentLanguageCommand :IRequest<CreatedDevelopmentLanguageDto>
    {
        public string Name { get; set; }







        public class CreateDevelopmentLanguageCommandHandler : IRequestHandler<CreateDevelopmentLanguageCommand, CreatedDevelopmentLanguageDto>
        {
            private readonly IDevelopmentLanguageRepository _developmentLanguageRepository;

            private readonly IMapper _mapper;

            private readonly DevelopmentLanguageBusinessRules _developmentLanguageBusinessRules;


            public CreateDevelopmentLanguageCommandHandler(IDevelopmentLanguageRepository developmentLanguageEntityRepository, IMapper mapper, DevelopmentLanguageBusinessRules developmentLanguageBusinessRules)
            {
                _developmentLanguageRepository = developmentLanguageEntityRepository;
                _mapper = mapper;
                _developmentLanguageBusinessRules = developmentLanguageBusinessRules;
            }

          




            public async Task<CreatedDevelopmentLanguageDto> Handle(CreateDevelopmentLanguageCommand request, CancellationToken cancellationToken)
            {
                await _developmentLanguageBusinessRules.DevelopmentLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
              //  await _developmentLanguageBusinessRules.DevelopmentLanguageNameCanNotBeBlankWhenInserted(request.Name);

                DevelopmentLanguage mappedDevelopmentLanguage= _mapper.Map<DevelopmentLanguage>(request);
                DevelopmentLanguage createdDevelopmentLanguage = await _developmentLanguageRepository.AddAsync(mappedDevelopmentLanguage);
                CreatedDevelopmentLanguageDto createdDevelopmentLanguageDto = _mapper.Map<CreatedDevelopmentLanguageDto>(createdDevelopmentLanguage);

                return createdDevelopmentLanguageDto;
                   
            }
        }


    }
}
