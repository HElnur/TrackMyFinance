using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;

namespace TrackMyFinance.Application.CQRS.v1.Type.Commands.Delete
{
    public class DeleteTypeCommand : IRequest<ApiResult<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteTypeCommand(Guid id)
            => Id = id;
    }
}
