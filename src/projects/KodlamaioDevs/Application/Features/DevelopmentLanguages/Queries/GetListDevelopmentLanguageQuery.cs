using Application.Features.DevelopmentLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentLanguages.Queries
{
    public class GetListDevelopmentLanguageQuery : IRequest<DevelopmentLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListDevelopmentLanguageQueryHandler : IRequestHandler<GetListDevelopmentLanguageQuery, DevelopmentLanguageListModel>
        {
            IDevelopmentLanguageRepository _developmentLanguageRepository;
            IMapper _mapper;

            public GetListDevelopmentLanguageQueryHandler(IDevelopmentLanguageRepository developmentLanguageRepository, IMapper mapper)
            {
                _developmentLanguageRepository = developmentLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DevelopmentLanguageListModel> Handle(GetListDevelopmentLanguageQuery request, CancellationToken cancellationToken)
            {

             IPaginate<DevelopmentLanguage> developmentLanguages = await  _developmentLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                DevelopmentLanguageListModel mappedDevelopmentLanguageListModel = _mapper.Map<DevelopmentLanguageListModel>(developmentLanguages);

                return mappedDevelopmentLanguageListModel;
            }
        }
    }
}
