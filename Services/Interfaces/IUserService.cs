using Services.Requests;
using Services.RequestsModels;
using Services.Responses;
using Services.ResponsesModels;
using Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task Import(byte[] bytes);
        Task<int> CreateAsync(RegisterViewModel model);
        int Delete(int id);
        int Update(UpdateUserRequestModel model);
        byte[] Export();

        List<ShortInfoUserResponse> GetAll();
        Task<UserLoginResponse> LoginAsync(UserLoginRequest loginRequest);
    }
}
