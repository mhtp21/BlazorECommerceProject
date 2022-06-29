using Application.Features.Commands.Payment;
using Application.Features.Queries.GetPaymentDetail;
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
    public class PaymentController : BaseController
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var offer = await mediator.Send(new GetPaymentDetailQuery(id));

            return Ok(offer);
        }

        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePayment([FromBody] DeletePaymentCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePayment([FromBody] UpdatePaymentCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}