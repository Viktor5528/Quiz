using DataLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repo.Interfaces
{
    public interface IQuizRepo
    {
        Task<int> Create(Quiz quiz);
        int Update(Quiz quiz);
        Task<int> Delete(int id);
        bool CheckIfQuizExisting(string name);
        List<Quiz> GetAll();
        List<Question> AddQuestionForQuiz(int questionId, int quizId );
        Quiz GetById(int id);
    }
}
