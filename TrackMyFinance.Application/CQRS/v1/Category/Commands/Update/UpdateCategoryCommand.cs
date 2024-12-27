using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Category.Update;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<ApiResult<UpdateCategoryResponse>>
    {
        public UpdateCategoryRequest Request { get; set; }

        public UpdateCategoryCommand(UpdateCategoryRequest request)
            => Request = request;
    }
}
