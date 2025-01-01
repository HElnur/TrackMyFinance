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
using TrackMyFinance.Models.v1.User.Login;
using TrackMyFinance.Models.v1.User.Register;

namespace TrackMyFinance.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJWTService _jwtService;

        public UserService(ApplicationDbContext context, IJWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (user == null)
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);

            bool check = user.Check(request.Password);

            if (!check)
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);

            var token = _jwtService.GenerateJwtToken<User>(user);

            var response = new LoginResponse
            {
                Token = token
            };

            return ApiResult<LoginResponse>.OK(response);
        }

        public async Task<ApiResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var existUser = await _context.Users.AnyAsync(x => x.Email == request.Email || x.UserName == request.Username);

            if (existUser)
                return ApiResult<RegisterResponse>.Error(ErrorCodes.DATA_IS_ALREADY_EXIST);

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
            };

            user.AddPassword(request.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var response = new RegisterResponse
            {
                Id = user.Id,
                Username = user.UserName,
            };

            return ApiResult<RegisterResponse>.OK(response);
        }
    }
}
