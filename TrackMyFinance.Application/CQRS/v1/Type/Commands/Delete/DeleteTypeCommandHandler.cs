using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Delete
{
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, ApiResult<Guid>>
    {
        private readonly ITypeService _service;

        public DeleteTypeCommandHandler(ITypeService service)
            => _service = service;

        public Task<ApiResult<Guid>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var result = _service.Delete(request.Id);

            return result;
        }
    }
}
