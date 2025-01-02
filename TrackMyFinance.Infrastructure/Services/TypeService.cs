using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Application.Interfaces;
using TrackMyFinance.Domain.Entities;
using TrackMyFinance.Domain.Enums;
using TrackMyFinance.Infrastructure.Data;
using TrackMyFinance.Models.v1.Type.Create;
using TrackMyFinance.Models.v1.Type.Get;
using TrackMyFinance.Models.v1.Type.Update;

namespace TrackMyFinance.Infrastructure.Services
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationDbContext _context;
        public TypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<CreateTypeResponse>> Create(CreateTypeRequest request)
        {

            var existType = await _context.Types.AnyAsync(x => x.Name == request.Name);

            if (existType)
                return ApiResult<CreateTypeResponse>.Error(ErrorCodes.DATA_IS_ALREADY_EXIST);

            var type = new Domain.Entities.Type
            {
                Name = request.Name,                
            };

            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();

            var response = new CreateTypeResponse
            {
                Id = type.Id,
                Name = type.Name,
            };

            return ApiResult<CreateTypeResponse>.OK(response);
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
