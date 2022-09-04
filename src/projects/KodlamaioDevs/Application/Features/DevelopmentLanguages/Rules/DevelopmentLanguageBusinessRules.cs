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


        public async Task DevelopmentLanguageNameCanNotBeDuplicatedWhenInsertedAndUpdated(string name)
        {
            IPaginate<DevelopmentLanguage> result = await _developmentLanguageRepository.GetListAsync(d => d.Name == name);
            if (result.Items.Any()) throw new BusinessException("Development language name exists");


        }

        public async Task DevelopmentLanguageNameCanNotBeBlankWhenInsertedAndUpdated(string name)
        {
        
            if (name=="") throw new BusinessException("Development language name can't be blank");
        }

        public async Task DevelopmentLanguageIdCanNotBeLessOneWhenDeleted(int id)
        {
            if (id <1)
            {
                throw new BusinessException("Development language id can't be less 1 for delete");
            }
        }


      

          
           
           
        
    }
}
