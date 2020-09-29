using DataLayer.Enums;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public List<Answer> Answers { get; set; }
        public bool Complexity { get; set; }
        public Theme Theme { get; set; }
    }
}
