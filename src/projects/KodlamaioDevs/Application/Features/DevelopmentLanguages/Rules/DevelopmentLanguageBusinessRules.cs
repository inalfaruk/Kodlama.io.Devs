using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentLanguages.Rules
{
    public class DevelopmentLanguageBusinessRules
    {
        private readonly IDevelopmentLanguageRepository _developmentLanguageRepository;

        public DevelopmentLanguageBusinessRules(IDevelopmentLanguageRepository developmentLanguageRepository)
        {
            _developmentLanguageRepository = developmentLanguageRepository;
        }


        public async Task DevelopmentLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<DevelopmentLanguage> result = await _developmentLanguageRepository.GetListAsync(d => d.Name == name);
            if (result.Items.Any()) throw new BusinessException("Development Language name exists");


        }

        public async Task DevelopmentLanguageNameCanNotBeBlankWhenInserted(string name)
        {
            IPaginate<DevelopmentLanguage> result = await _developmentLanguageRepository.GetListAsync(d => d.Name.Length<=0);
            if (result.Items.Any()) throw new BusinessException("Development Language name can't be blank");
        }
    }
}
