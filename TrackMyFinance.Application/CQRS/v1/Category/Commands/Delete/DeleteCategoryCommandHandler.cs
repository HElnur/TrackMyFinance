using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResult<Guid>>
    {
        private readonly ICategoryService _service;

        public DeleteCategoryCommandHandler(ICategoryService service)
            => _service = service;

        public async Task<ApiResult<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Delete(request.Id);

            return result;
        }
    }
}
