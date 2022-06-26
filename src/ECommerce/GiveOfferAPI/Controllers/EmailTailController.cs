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
        public async Task<IActionResult> Create([FromBody] CreateEmailTailCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteEmailTail(DeleteEmailTailCommand command)
        {
            var guid = await mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateEmailTail([FromBody] UpdateEmailTailCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}