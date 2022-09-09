using Application.Features.SubTechs.Commands.CreateSubTech;
using Application.Features.SubTechs.Commands.DeleteSubTech;
using Application.Features.SubTechs.Commands.UpdateSubTech;
using Application.Features.SubTechs.Dtos;
using Application.Features.SubTechs.Models;
using Application.Features.SubTechs.Queries.GetByIdSubTech;
using Application.Features.SubTechs.Queries.GetListSubTech;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTechsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubTechQuery getListSubTechQuery = new() { PageRequest = pageRequest };
            SubTechListModel result = await Mediator.Send(getListSubTechQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSubTechQuery getByIdSubTechQuery)
        {
            SubTechGetByIdDto subTechGetByIdDto = await Mediator.Send(getByIdSubTechQuery);
            return Ok(subTechGetByIdDto);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubTechCommand createSubTechCommand)
        {
            CreatedSubTechDto result = await Mediator.Send(createSubTechCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSubTechCommand deleteSubTechCommand)
        {
            DeletedSubTechDto result = await Mediator.Send(deleteSubTechCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubTechCommand updateSubTechCommand)
        {
            UpdatedSubTechDto result = await Mediator.Send(updateSubTechCommand);
            return Ok(result);
        }










    }
}
