using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public Context(DbContextOptions<Context> dbContext) : base(dbContext)
        {
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<UserQuiz>().HasKey(k => new { k.UserId, k.QuizId });
            mb.Entity<UserQuiz>().HasOne(u => u.User).WithMany(u => u.UserQuizzes).HasForeignKey(uid=>uid.UserId);
            mb.Entity<UserQuiz>().HasOne(q => q.Quiz).WithMany(q => q.UserQuizzes).HasForeignKey(qid => qid.QuizId);
        }
    }
}
