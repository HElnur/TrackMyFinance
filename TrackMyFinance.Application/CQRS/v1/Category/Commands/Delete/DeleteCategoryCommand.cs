using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;

namespace TrackMyFinance.Application.CQRS.v1.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<ApiResult<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
            => Id = id;
    }
}
