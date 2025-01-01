using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Type.Create;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Create
{
    public class CreateTypeCommand : IRequest<ApiResult<CreateTypeResponse>>
    {
        public CreateTypeRequest Request { get; set; }

        public CreateTypeCommand(CreateTypeRequest request)
            => Request = request;
    }
}
