using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Core;
using TrackMyFinance.Models.v1.User.Login;
using TrackMyFinance.Models.v1.User.Register;

namespace TrackMyFinance.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult<RegisterResponse>> Register(RegisterRequest request);
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
    }
}