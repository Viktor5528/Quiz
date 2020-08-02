using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IQuizRepo
    {
        int Create(Quiz quiz);
        int Update(Quiz quiz);
        int Delete(Quiz quiz);
        List<Quiz> GetAll();
    }
}
