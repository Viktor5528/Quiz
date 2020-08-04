using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.Requests
{
    public class CreateQuestionRequestModel
    {
        public string Text { get; set; }
        public List<CreateAnswerRequestModel> Answers { get; set; }
        public bool Complexity { get; set; }
    }
}
