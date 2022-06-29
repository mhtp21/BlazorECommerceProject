using Application.Features.Commands.Purchase;
using Application.Features.Queries.GetPurchaseDetail;
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
    public class PurchaseController : BaseController
    {
        private readonly IMediator mediator;

        public PurchaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var purchase = await mediator.Send(new GetPurchaseDetailQuery(id));

            return Ok(purchase);
        }

        [HttpPost]
        [Route("CreatePurchase")]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePurchase([FromBody] DeletePurchaseCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePurchase([FromBody] UpdatePurchaseCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}