using DataLayer.Enums;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Theme Theme { get; set; }
        public List<Question> Questions { get; set; }
        public List<UserQuiz> UserQuizzes { get; set; }
    }
}
