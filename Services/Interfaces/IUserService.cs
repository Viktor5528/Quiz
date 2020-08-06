using Services.Requests;
using Services.Responses;
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
    }
}
