using Domen.Models;

namespace Services.Interfaces;

public interface IUser
{

    public interface IUserService
    {
        Task<BaseResponse<UserResponse>> Login(UserRequest request);

        Task<BaseResponse> Register(RegisterRequest request);

        Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request);
    }
}


{
    Task<User> Add(string Supername,  string Name, string Phone, string pas1,string pas2);

    Task<SearchUserResponse> SearchUser(UserGetModel model);

    Task Update(long id, string Supername,string Name,string Phone, string pas1,string pas2);
    Task DeleteUserAsync(long id);

}
