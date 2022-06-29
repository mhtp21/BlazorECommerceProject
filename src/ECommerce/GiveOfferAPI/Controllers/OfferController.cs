using Application.Features.Commands.Offer;
using Application.Features.Queries.GetOfferDetail;
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
    public class OfferController : BaseController
    {
        private readonly IMediator mediator;
        public OfferController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var offer = await mediator.Send(new GetOfferDetailQuery(id));

            return Ok(offer);
        }

        [HttpPost]
        [Route("CreateOffer")]
        public async Task<IActionResult> Create([FromBody] CreateOfferCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOffer([FromBody] DeleteOfferCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}