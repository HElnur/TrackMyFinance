using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.CQRS.v1.User.Commands.Login;
using TrackMyFinance.Application.CQRS.v1.User.Commands.Register;
using TrackMyFinance.Models.v1.User.Login;
using TrackMyFinance.Models.v1.User.Register;

namespace TrackMyFinance.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/user")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<ApiResult<RegisterResponse>>> Register([FromForm] RegisterRequest request)
            => await _mediator.Send(new RegisterCommand(request));

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult<LoginResponse>>> Login([FromForm]LoginRequest request)
            => await _mediator.Send(new LoginCommand(request));
    }
}
