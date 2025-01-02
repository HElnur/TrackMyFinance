using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Category.Get;

namespace TrackMyFinance.Application.CQRS.v1.Category.Queries.Get
{
    public class GetCategoryQuery : IRequest<ApiResult<List<GetCategoryResponse>>>
    {
        public GetCategoryRequest Request { get; set; }

        public GetCategoryQuery(GetCategoryRequest request)
            => Request = request;
    }
}
