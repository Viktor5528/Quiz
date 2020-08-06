using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IUserRepo
    {
        int Create(User user);
        int Update(User user);
        int Delete(int id);
        List<User> GetAll();
        User GetById(int id);
        void Save();
    }
}
