using Services.Requests;
using Services.Responses;
using Services.ResponsesModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IQuizService
    {
        int Create(CreateQuizRequestModel model);
        int Delete(int id);
        int Update(UpdateQuizRequestModel model);

        List<ShortInfoQuizResponse> GetAll();
        List<ShortInfoQuestionResponse> AddQuestionForQuiz(int questionId, int quizId);
    }
}
