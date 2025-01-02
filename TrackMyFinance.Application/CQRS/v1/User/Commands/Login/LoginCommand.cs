using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.User.Login;

namespace TrackMyFinance.Application.CQRS.v1.User.Commands.Login
{
    public class LoginCommand : IRequest<ApiResult<LoginResponse>>
    {
        public LoginRequest Request { get; set; }

        public LoginCommand(LoginRequest request)
            => Request = request;
    }
}
