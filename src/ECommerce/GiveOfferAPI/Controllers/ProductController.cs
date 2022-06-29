using Application.Features.Commands.Product;
using Application.Features.Queries.GetProductDetail;
using Application.Features.Queries.GetMainPageProducts;
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
    public class ProductController : BaseController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await mediator.Send(new GetProductDetailQuery(id));

            return Ok(product);
        }

        [HttpGet]
        [Route("MainPageProducts")]
        public async Task<IActionResult> GetMainPageProducts(Guid UserId ,int page, int pageSize)
        {
            var products = await mediator.Send(new GetMainPageProductsQuery(UserId, page, pageSize));

            return Ok(products);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}
