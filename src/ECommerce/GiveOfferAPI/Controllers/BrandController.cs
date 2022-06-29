using Application.Features.Commands.Brand;
using Application.Features.Queries.GetBrandDetail;
using Application.Features.Queries.GetListBrand;
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
    public class BrandController : BaseController
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            mediator  = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var brand = await mediator.Send(new GetBrandDetailQuery(id));

            return Ok(brand);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListBrandQuery query)
        {
            var brand = await mediator.Send(query);
            return Ok(brand);
        }

        [HttpGet]
        [Route("BrandName/{brandName}")]
        public async Task<IActionResult> GetByBrandName(string brandName)
        {
            var brand = await mediator.Send(new GetBrandDetailQuery(Guid.Empty, brandName));

            return Ok(brand);
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteBrand([FromBody] DeleteBrandCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }


    }
}
