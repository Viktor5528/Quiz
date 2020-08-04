using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.ResponsesModels
{
    public class ShortInfoQuizResponse
    {
        public string Name { get; set; }
        public List<QuestionResponseModel> Questions { get; set; }
    }
}
