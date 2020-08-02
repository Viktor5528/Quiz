using DataLayer.Entity;
using DataLayer.Enums;
using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserRequestModel model);
        int Delete(User user);//UserId
        int Update(User user);//UserId
        
        List<ShortInfoUserResponse> GetAll();
    }
}
