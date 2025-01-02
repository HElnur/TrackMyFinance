using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.User.Register;

namespace TrackMyFinance.Application.CQRS.v1.User.Commands.Register
{
    public class RegisterCommand : IRequest<ApiResult<RegisterResponse>>
    {
        public RegisterRequest Request { get; set; }

        public RegisterCommand(RegisterRequest request)
            => Request = request;
    }
}
