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
using TrackMyFinance.Models.v1.Category.Create;
using TrackMyFinance.Models.v1.Category.Get;
using TrackMyFinance.Models.v1.Category.Update;

namespace TrackMyFinance.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<CreateCategoryResponse>> Create(CreateCategoryRequest request)
        {
            var existCategory = await _context.Categories.AnyAsync(x => x.Name == request.Name);

            if (existCategory)
                return ApiResult<CreateCategoryResponse>.Error(ErrorCodes.DATA_IS_ALREADY_EXIST);

            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var response = new CreateCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };

            return ApiResult<CreateCategoryResponse>.OK(response);
        }

        public async Task<ApiResult<Guid>> Delete(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return ApiResult<Guid>.Error(ErrorCodes.INFORMATION_NOT_FOUND);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return ApiResult<Guid>.OK(id);
        }

        public async Task<ApiResult<List<GetCategoryResponse>>> Get(GetCategoryRequest request)
        {
            var query =  _context.Categories.AsQueryable().AsNoTracking();

            if (request.Id != null)
                query = query.Where(x => x.Id == request.Id);

            if(request.Name != null)
                query = query.Where(x => x.Name == request.Name);

            var categories = await query.Select(x => new GetCategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreateAt = x.CreateAt.ToString("d MMMM yyyy"),
                UpdateAt = x.UpdateAt.ToString("d MMMM yyyy"),
            }).ToListAsync();

            return ApiResult<List<GetCategoryResponse>>.OK(categories);
        }

        public async Task<ApiResult<UpdateCategoryResponse>> Update(UpdateCategoryRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if(category == null)
                return ApiResult<UpdateCategoryResponse>.Error(ErrorCodes.INFORMATION_NOT_FOUND);

            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync();

            var response = new UpdateCategoryResponse
            {
                Id= category.Id,    
                Name = category.Name,
            };

            return ApiResult<UpdateCategoryResponse>.OK(response);
        }
    }
}
