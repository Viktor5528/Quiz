using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserRequestModel model);
        int Delete(int id);
        int Update(UpdateUserRequestModel model);

        List<ShortInfoUserResponse> GetAll();
    }
}
