using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer.Repo.Interfaces
{
    public interface IQuizRepo
    {
        int Create(Quiz quiz);
        int Update(Quiz quiz);
        int Delete(int id);
        bool CheckIfQuizExisting(string name);
        List<Quiz> GetAll();
        List<Question> AddQuestionForQuiz(int questionId, int quizId );
        Quiz GetById(int id);
    }
}
