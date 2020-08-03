using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAnswerService
    {
        int Create(CreateAnswerRequestModel model);
        int Update(UpdateAnswerRequestModel model);
        List<ShortInfoAnswerResponse> GetAll();
        int Delete(int id);
    }
}
