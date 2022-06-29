using Application.Features.Commands.User;
using Application.Features.Queries.GetUserDetail;
using Application.Features.Queries.GetListUserAccountDetail;
using Common.Models.RequestModels;
using Common.Models.RequestModels.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiveOfferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserDetailQuery(id));

            return Ok(user);
        }

        [HttpGet]
        [Route("UserName/{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var user = await mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));

            return Ok(user);
        }

        [HttpGet]
        [Route("User/{id}")]
        public async Task<IActionResult> GetByAccountDetail(Guid userId)
        {
            var user = await mediator.Send(new GetUserAccountQuery(userId));
            return Ok(user);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpDelete]
        [Authorize]
        [Route("Delete")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        } 

        [HttpPut]
        [Route("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }
    }
}
