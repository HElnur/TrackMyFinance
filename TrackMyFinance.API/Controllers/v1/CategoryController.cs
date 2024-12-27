using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMyFinance.API.Helpers;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.CQRS.v1.Category.Commands.Create;
using TrackMyFinance.Application.CQRS.v1.Category.Commands.Delete;
using TrackMyFinance.Application.CQRS.v1.Category.Commands.Update;
using TrackMyFinance.Application.CQRS.v1.Category.Queries.Get;
using TrackMyFinance.Models.v1.Category.Create;
using TrackMyFinance.Models.v1.Category.Get;
using TrackMyFinance.Models.v1.Category.Update;

namespace TrackMyFinance.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/category")]
    [ApiVersion("1.0")]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<GetCategoryResponse>>>> Get([FromQuery] GetCategoryRequest request)
        {
            if(!User.Identity?.IsAuthenticated ?? false)
            {
                return new UnAuthActionResult();
            }

            return await _mediator.Send(new GetCategoryQuery(request));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateCategoryResponse>>> Create([FromForm] CreateCategoryRequest request)
            => await _mediator.Send(new CreateCategoryCommand(request));

        [HttpPut]
        public async Task<ActionResult<ApiResult<UpdateCategoryResponse>>> Update([FromForm] UpdateCategoryRequest request)
            => await _mediator.Send(new UpdateCategoryCommand(request));

        [HttpDelete]
        public async Task<ActionResult<ApiResult<Guid>>> Delete([FromForm] Guid id)
            => await _mediator.Send(new DeleteCategoryCommand(id));
    }
}
