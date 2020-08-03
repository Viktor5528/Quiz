using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    interface IQuestionService
    {
        int Create(CreateQuestionRequestModel model);
        int Update(UpdateQuestionRequestModel model);
        List<ShortInfoQuestionResponse> GetAll();
        int Delete(int id);
    }
}
