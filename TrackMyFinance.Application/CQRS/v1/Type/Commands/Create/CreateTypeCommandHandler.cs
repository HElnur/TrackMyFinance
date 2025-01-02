using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Type.Create;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Create
{
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, ApiResult<CreateTypeResponse>>
    {
        private readonly ITypeService _service;

        public CreateTypeCommandHandler(ITypeService service)
            => _service = service;

        public async Task<ApiResult<CreateTypeResponse>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Create(request.Request);

            return result;
        }
    }
}
