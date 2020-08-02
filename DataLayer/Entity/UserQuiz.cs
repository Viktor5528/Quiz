namespace DataLayer.Entity
{
    public class UserQuiz
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
