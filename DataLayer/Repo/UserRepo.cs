using DataLayer.Entity;
using DataLayer.Enums;
using DataLayer.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        Context db;
        public UserRepo(Context context)
        {
            db = context;
        }
        public int Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }
        public int Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
            return user.Id;
        }
        public int Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user.Id;
        }
        
        public List<User> GetAll()
        {
            return db.Users.ToList();
        }
    }
}
