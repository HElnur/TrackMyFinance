using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.CQRS.v1.Type.Commands.Create;
using TrackMyFinance.Application.CQRS.v1.Type.Commands.Delete;
using TrackMyFinance.Application.CQRS.v1.Type.Commands.Update;
using TrackMyFinance.Application.CQRS.v1.Type.Queries.Get;
using TrackMyFinance.Models.v1.Type.Create;
using TrackMyFinance.Models.v1.Type.Get;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/type")]
    [ApiVersion("1.0")]
    public class TypeController : BaseController
    {
        private readonly IMediator _mediator;

        public TypeController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateTypeResponse>>> Create([FromForm]CreateTypeRequest request)
            => await _mediator.Send(new CreateTypeCommand(request));

        [HttpPut]
        public async Task<ActionResult<ApiResult<UpdateTypeResponse>>> Update([FromForm]UpdateTypeRequest request)
            => await _mediator.Send(new UpdateTypeCommand(request));

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<GetTypeResponse>>>> Get([FromQuery]GetTypeRequest request)
            => await _mediator.Send(new GetTypeQuery(request));

        [HttpDelete]
        public async Task<ActionResult<ApiResult<Guid>>> Delete([FromForm]Guid id)
            => await _mediator.Send(new DeleteTypeCommand(id));
    }
}
