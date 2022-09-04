using Application.Features.DevelopmentLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentLanguages.Models
{
    public class DevelopmentLanguageListModel : BasePageableModel
    {

        public List<DevelopmentLanguageListDto> Items { get; set; }



    }
}
