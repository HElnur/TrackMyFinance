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

        public async Task<ApiResult<Guid>> Delete(Guid id)
        {
            var type = await _context.Types.FindAsync(id);

            if (type == null)
                return ApiResult<Guid>.Error(ErrorCodes.INFORMATION_NOT_FOUND);

            _context.Types.Remove(type);
            await _context.SaveChangesAsync();

            return ApiResult<Guid>.OK(type.Id);
        }

        public async Task<ApiResult<List<GetTypeResponse>>> Get(GetTypeRequest request)
        {
            var query = _context.Types.AsQueryable().AsNoTracking();

            if(request.Id != null)
                query = query.Where(x => x.Id == request.Id);

            if (request.Name != null)
                query = query.Where(x => x.Name == request.Name);

            var types = await query.Select(x => new GetTypeResponse
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt.ToString("dd MMMM yyyy"),
                UpdateAt = x.UpdateAt.ToString("dd MMMM yyyy"),
            }).ToListAsync();

            return ApiResult<List<GetTypeResponse>>.OK(types);
        }

        public async Task<ApiResult<UpdateTypeResponse>> Update(UpdateTypeRequest request)
        {
            var type = await _context.Types.FindAsync(request.Id);

            if (type == null)
                return ApiResult<UpdateTypeResponse>.Error(ErrorCodes.INFORMATION_NOT_FOUND);

            type.Name = request.Name;

            await _context.SaveChangesAsync();

            var response = new UpdateTypeResponse
            {
                Id = type.Id,
                Name = type.Name,
            };

            return ApiResult<UpdateTypeResponse>.OK(response);
        }
    }
}
