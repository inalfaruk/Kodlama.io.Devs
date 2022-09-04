using Application.Features.DevelopmentLanguages.Commands.CreateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Commands.UpdateDelevopmentLanguage;
using Application.Features.DevelopmentLanguages.Dtos;
using Application.Features.DevelopmentLanguages.Models;
using Application.Features.DevelopmentLanguages.Queries;
using Core.Application.Requests;
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





        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListDevelopmentLanguageQuery getListDevelopmentLanguageQuery = new() { PageRequest = pageRequest };
            DevelopmentLanguageListModel  result = await Mediator.Send(getListDevelopmentLanguageQuery);

            return Created("", result);

        }





        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
          DeleteDevelopmentLanguageCommand deleteDevelopmentLanguageCommand = new() { Id = id };
            DeletedDevelopmentLanguageDto result = await Mediator.Send(deleteDevelopmentLanguageCommand);
            return Ok(result);
        }



        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] string name)
        {
            UpdateDevelopmentLanguageCommand updateDevelopmentLanguageCommand = new() { Id = id, Name = name };
            UpdatedDevelopmentLanguageDto result = await Mediator.Send(updateDevelopmentLanguageCommand);
            return Ok(result);
        }

    }
}
