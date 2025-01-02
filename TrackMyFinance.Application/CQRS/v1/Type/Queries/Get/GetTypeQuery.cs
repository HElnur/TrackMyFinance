using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Type.Get;

namespace TrackMyFinance.Application.CQRS.v1.Type.Queries.Get
{
    public class GetTypeQuery : IRequest<ApiResult<List<GetTypeResponse>>>
    {
        public GetTypeRequest Request { get; set; }

        public GetTypeQuery(GetTypeRequest request)
            => Request = request;
    }
}
