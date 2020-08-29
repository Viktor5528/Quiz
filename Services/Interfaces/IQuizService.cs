using Services.Requests;
using Services.Responses;
using Services.ResponsesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IQuizService
    {
        Task<int> Create(CreateQuizRequestModel model);
        Task<int> Delete(int id);
        int Update(UpdateQuizRequestModel model);

        List<ShortInfoQuizResponse> GetAll();
        List<ShortInfoQuestionResponse> AddQuestionForQuiz(int questionId, int quizId);
    }
}
