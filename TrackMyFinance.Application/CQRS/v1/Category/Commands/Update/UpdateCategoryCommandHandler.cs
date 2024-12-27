using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Category.Update;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResult<UpdateCategoryResponse>>
    {
        private readonly ICategoryService _service;

        public UpdateCategoryCommandHandler(ICategoryService service)
            => _service = service;

        public async Task<ApiResult<UpdateCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Update(request.Request);

            return result;
        }
    }
}
