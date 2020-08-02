using DataLayer.Enums;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public List<UserQuiz> UserQuizzes { get; set; }
    }
}
