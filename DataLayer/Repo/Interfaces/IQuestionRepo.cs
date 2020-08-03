using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IQuestionRepo
    {
        int Create(Question question);
        int Update(Question question);
        int Delete(int id);
        List<Question> GetAll();
        Question GetById(int id);
    }
}
