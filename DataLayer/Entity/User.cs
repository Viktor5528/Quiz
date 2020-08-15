using DataLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class User : IdentityUser<int>
    {
        
        public string Login { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public List<UserQuiz> UserQuizzes { get; set; }
    }
}
