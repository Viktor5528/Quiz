using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IUserRepo
    {
        int Create(User user);
        int Update(User user);
        int Delete(User user);
        List<User> GetAll();
    }
}
