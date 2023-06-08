using Services.Enums;
using Services.Services.UsersServices;

namespace Services.Interfaces;

public interface IUserService
{
    Task<BaseResponse<UserResponse>> Login(UserRequest request);

    Task<BaseResponse> Register(RegisterRequest request);

    Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request);
}