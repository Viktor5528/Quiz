using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.Requests
{
    public class CreateQuizRequestModel
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
