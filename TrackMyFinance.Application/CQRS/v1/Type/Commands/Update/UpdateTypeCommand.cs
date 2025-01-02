using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Update
{
    public class UpdateTypeCommand : IRequest<ApiResult<UpdateTypeResponse>>
    {
        public UpdateTypeRequest Request { get; set; }

        public UpdateTypeCommand(UpdateTypeRequest request)
            => Request = request;
    }
}
