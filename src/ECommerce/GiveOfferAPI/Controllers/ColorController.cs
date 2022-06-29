using Application.Features.Commands.Color;
using Application.Features.Queries.GetColorDetail;
using Application.Features.Queries.GetListColor;
using Common.Models.RequestModels;
using Common.Models.RequestModels.Delete;
using Common.Models.RequestModels.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiveOfferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : BaseController
    {
        private readonly IMediator mediator;

        public ColorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var color = await mediator.Send(new GetColorDetailQuery(id));

            return Ok(color);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListColorQuery query)
        {
            var color = await mediator.Send(query);
            return Ok(color);
        }

        [HttpGet]
        [Route("ColorName/{colorName}")]
        public async Task<IActionResult> GetByName(string colorName)
        {
            var color = await mediator.Send(new GetColorDetailQuery(Guid.Empty, colorName));

            return Ok(color);
        }

        [HttpPost]
        [Route("CreateColor")]
        public async Task<IActionResult> Create([FromBody] CreateColorCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteColor([FromBody] DeleteColorCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateColor([FromBody] UpdateColorCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}
