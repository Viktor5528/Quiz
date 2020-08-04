using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.ResponsesModels
{
    public class ShortInfoQuizResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionResponseModel> Questions { get; set; }
        public int Theme { get; set; }
    }
}
