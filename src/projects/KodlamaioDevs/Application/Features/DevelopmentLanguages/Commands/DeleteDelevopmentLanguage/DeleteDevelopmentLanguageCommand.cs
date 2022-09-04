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
    public class DeleteDevelopmentLanguageCommand : IRequest<DeletedDevelopmentLanguageDto>
    {
        public int Id { get; set; }







        public class DeleteDevelopmentLanguageCommandHandler : IRequestHandler<DeleteDevelopmentLanguageCommand, DeletedDevelopmentLanguageDto>
        {
            private readonly IDevelopmentLanguageRepository _developmentLanguageRepository;

            private readonly IMapper _mapper;

            private readonly DevelopmentLanguageBusinessRules _developmentLanguageBusinessRules;


            public DeleteDevelopmentLanguageCommandHandler(IDevelopmentLanguageRepository developmentLanguageEntityRepository, IMapper mapper, DevelopmentLanguageBusinessRules developmentLanguageBusinessRules)
            {
                _developmentLanguageRepository = developmentLanguageEntityRepository;
                _mapper = mapper;
                _developmentLanguageBusinessRules = developmentLanguageBusinessRules;
            }






            public async Task<DeletedDevelopmentLanguageDto> Handle(DeleteDevelopmentLanguageCommand request, CancellationToken cancellationToken)
            {

                  await   _developmentLanguageBusinessRules.DevelopmentLanguageIdCanNotBeLessOneWhenDeleted(request.Id);

              

                DevelopmentLanguage mappedDevelopmentLanguage = _mapper.Map<DevelopmentLanguage>(request);
                DevelopmentLanguage deletedDevelopmentLanguage = await _developmentLanguageRepository.DeleteAsync(mappedDevelopmentLanguage);
                DeletedDevelopmentLanguageDto deletedDevelopmentLanguageDto = _mapper.Map<DeletedDevelopmentLanguageDto>(deletedDevelopmentLanguage);

                return deletedDevelopmentLanguageDto;

            }
        }


    }
}
