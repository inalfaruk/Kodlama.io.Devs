using Application.Features.DevelopmentLanguages.Commands.CreateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentLanguageController : BaseController
    {


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDevelopmentLanguageCommand createDevelopmentLanguageCommand)
        {
            CreatedDevelopmentLanguageDto result = await Mediator.Send(createDevelopmentLanguageCommand);

                return Created("", result);

        }

    }
}
