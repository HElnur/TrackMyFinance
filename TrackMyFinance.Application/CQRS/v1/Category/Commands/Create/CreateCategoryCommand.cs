using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Category.Create;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<ApiResult<CreateCategoryResponse>>
    {
        public CreateCategoryRequest Request { get; set; }

        public CreateCategoryCommand(CreateCategoryRequest request)
        {

            Request = request;

        }
    }
}
