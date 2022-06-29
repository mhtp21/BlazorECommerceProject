using Application.Features.Commands.Category;
using Application.Features.Queries.GetCategoryDetail;
using Application.Features.Queries.GetListCategory;
using Application.Features.Queries.GetCategoryListProduct;
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
    public class CategoryController : BaseController
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await mediator.Send(new GetCategoryDetailQuery(id));
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryProduct(GetProductsFromCategoriesQuery query)
        {
            var category = await mediator.Send(query);
            return Ok(category);
        }

        [HttpGet]
        [Route("CategoryAllList")]
        public async Task<IActionResult> GetAll([FromQuery]GetListCategoryQuery query)
        {
            var category = await mediator.Send(query);
            return Ok(category);
        }

        [HttpGet]
        [Route("CategoryName/{categoryName}")]
        public async Task<IActionResult> GetByName(string categoryName)
        {
            var category = await mediator.Send(new GetCategoryDetailQuery(Guid.Empty, categoryName));

            return Ok(category);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}