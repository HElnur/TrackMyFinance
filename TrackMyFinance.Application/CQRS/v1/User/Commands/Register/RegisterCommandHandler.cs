using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.User.Register;

namespace TrackMyFinance.Application.CQRS.v1.User.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResult<RegisterResponse>>
    {
        private readonly IUserService _service;

        public RegisterCommandHandler(IUserService service)
            => _service = service;

        public async Task<ApiResult<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Register(request.Request);

            return result;
        }
    }
}
