using DataLayer.Entity;
using System.Collections.Generic;

namespace Services.Requests
{
    public class UpdateQuizRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public int Theme { get; set; }
    }
}
