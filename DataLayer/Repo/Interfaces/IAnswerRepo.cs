using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IAnswerRepo
    {
        int Create(Answer answer);
        int Update(Answer answer);
        int Delete(Answer answer);
        List<Answer> GetAll();
        Answer GetById(int id);
    }
}
