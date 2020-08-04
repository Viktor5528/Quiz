using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.Requests
{
    public class CreateQuizRequestModel
    {
        public string Name { get; set; }
        public int Theme { get; set; }
        public List<CreateQuestionRequestModel> Questions { get; set; }
    }
}
