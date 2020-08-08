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
        Task<int> CreateAsync(RegisterViewModel model);
        int Delete(int id);
        int Update(UpdateUserRequestModel model);

        List<ShortInfoUserResponse> GetAll();
        Task<UserLoginResponse> LoginAsync(UserLoginRequest loginRequest);
    }
}
