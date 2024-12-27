using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Category.Create;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResult<CreateCategoryResponse>>
    {
        private readonly ICategoryService _service;

        public CreateCategoryCommandHandler(ICategoryService service)
            => _service = service;

        public async Task<ApiResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Create(request.Request);

            return result;
        }
    }
}
