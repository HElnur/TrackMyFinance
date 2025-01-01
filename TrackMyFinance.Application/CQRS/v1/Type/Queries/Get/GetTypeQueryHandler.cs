using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Type.Get;

namespace TrackMyFinance.Application.CQRS.v1.Type.Queries.Get
{
    public class GetTypeQueryHandler : IRequestHandler<GetTypeQuery, ApiResult<List<GetTypeResponse>>>
    {
        private readonly ITypeService _service;

        public GetTypeQueryHandler(ITypeService service)
            => _service = service;

        public async Task<ApiResult<List<GetTypeResponse>>> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.Get(request.Request);

            return result;
        }
    }
}
