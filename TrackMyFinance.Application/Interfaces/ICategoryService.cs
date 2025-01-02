using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.Category.Create;
using TrackMyFinance.Models.v1.Category.Get;
using TrackMyFinance.Models.v1.Category.Update;

namespace TrackMyFinance.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResult<CreateCategoryResponse>> Create(CreateCategoryRequest request);
        Task<ApiResult<UpdateCategoryResponse>> Update(UpdateCategoryRequest request);
        Task<ApiResult<List<GetCategoryResponse>>> Get(GetCategoryRequest request);
        Task<ApiResult<Guid>> Delete(Guid id);
    }
}
