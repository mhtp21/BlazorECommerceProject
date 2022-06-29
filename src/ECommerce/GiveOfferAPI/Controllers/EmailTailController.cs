using Application.Features.Commands.EmailTail;
using Application.Features.Queries.GetEmailTailDetail;
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
    public class EmailTailController : BaseController
    {
        private readonly IMediator mediator;

        public EmailTailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var emailTail = await mediator.Send(new GetEmailTailDetailQuery(id));

            return Ok(emailTail);
        }

        [HttpGet]
        [Route("Email/{email}")]
        public async Task<IActionResult> GetByName(string email)
        {
            var color = await mediator.Send(new GetEmailTailDetailQuery(Guid.Empty, email));

            return Ok(color);
        }

        [HttpPost]
        [Route("CreateEmailTail")]
        public async Task<IActionResult> CreateEmail([FromBody] CreateEmailTailCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteEmail([FromBody] DeleteEmailTailCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailTailCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}