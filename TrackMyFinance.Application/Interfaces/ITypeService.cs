using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Type.Create;
using TrackMyFinance.Models.v1.Type.Get;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.Application.Interfaces
{
    public interface ITypeService
    {
        Task<ApiResult<CreateTypeResponse>> Create(CreateTypeRequest request);  
        Task<ApiResult<UpdateTypeResponse>> Update(UpdateTypeRequest request);
        Task<ApiResult<List<GetTypeResponse>>> Get(GetTypeRequest request);
        Task<ApiResult<Guid>> Delete(Guid id);
    }
}
