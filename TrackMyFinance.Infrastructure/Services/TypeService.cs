using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Models.v1.Type.Create;
using TrackMyFinance.Models.v1.Type.Get;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.Infrastructure.Services
{
    public class TypeService : ITypeService
    {
        public Task<ApiResult<CreateTypeResponse>> Create(CreateTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<Guid>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<GetTypeResponse>>> Get(GetTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<UpdateTypeResponse>> Update(UpdateTypeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
