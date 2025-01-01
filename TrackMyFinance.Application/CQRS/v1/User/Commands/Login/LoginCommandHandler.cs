using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.User.Login;

namespace TrackMyFinance.Application.CQRS.v1.User.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResult<LoginResponse>>
    {
        private readonly IUserService _service;

        public LoginCommandHandler(IUserService service)
            => _service = service;

        public async Task<ApiResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Login(request.Request);

            return result;
        }
    }
}
