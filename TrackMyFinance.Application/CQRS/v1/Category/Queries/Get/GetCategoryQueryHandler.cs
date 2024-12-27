using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Category.Get;

namespace TrackMyFinance.Application.CQRS.v1.Category.Queries.Get
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ApiResult<List<GetCategoryResponse>>>
    {
        private readonly ICategoryService _service;

        public GetCategoryQueryHandler(ICategoryService service)
            => _service = service;

        public async Task<ApiResult<List<GetCategoryResponse>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.Get(request.Request);

            return result;
        }
    }
}
