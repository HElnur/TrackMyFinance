using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Update
{
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, ApiResult<UpdateTypeResponse>>
    {
        private readonly ITypeService _service;

        public UpdateTypeCommandHandler(ITypeService service)
            => _service = service;

        public async Task<ApiResult<UpdateTypeResponse>> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Update(request.Request);

            return result;
        }
    }
}
