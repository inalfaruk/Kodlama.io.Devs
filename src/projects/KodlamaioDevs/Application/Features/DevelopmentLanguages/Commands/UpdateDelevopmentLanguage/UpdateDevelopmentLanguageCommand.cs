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

namespace Application.Features.DevelopmentLanguages.Commands.UpdateDelevopmentLanguage
{
    public class UpdateDevelopmentLanguageCommand : IRequest<UpdatedDevelopmentLanguageDto>
    {
        public string Name { get; set; }

        public int Id { get; set; }






        public class UpdateDevelopmentLanguageCommandHandler : IRequestHandler<UpdateDevelopmentLanguageCommand, UpdatedDevelopmentLanguageDto>
        {
            private readonly IDevelopmentLanguageRepository _developmentLanguageRepository;

            private readonly IMapper _mapper;

            private readonly DevelopmentLanguageBusinessRules _developmentLanguageBusinessRules;


            public UpdateDevelopmentLanguageCommandHandler(IDevelopmentLanguageRepository developmentLanguageEntityRepository, IMapper mapper, DevelopmentLanguageBusinessRules developmentLanguageBusinessRules)
            {
                _developmentLanguageRepository = developmentLanguageEntityRepository;
                _mapper = mapper;
                _developmentLanguageBusinessRules = developmentLanguageBusinessRules;
            }






            public async Task<UpdatedDevelopmentLanguageDto> Handle(UpdateDevelopmentLanguageCommand request, CancellationToken cancellationToken)
            {

                await _developmentLanguageBusinessRules.DevelopmentLanguageNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                await _developmentLanguageBusinessRules.DevelopmentLanguageNameCanNotBeBlankWhenInsertedAndUpdated(request.Name);

                DevelopmentLanguage mappedDevelopmentLanguage = _mapper.Map<DevelopmentLanguage>(request);
                DevelopmentLanguage updatedDevelopmentLanguage = await _developmentLanguageRepository.UpdateAsync(mappedDevelopmentLanguage);
                UpdatedDevelopmentLanguageDto updatedDevelopmentLanguageDto = _mapper.Map<UpdatedDevelopmentLanguageDto>(updatedDevelopmentLanguage);

                return updatedDevelopmentLanguageDto;

            }
        }


    }
}
