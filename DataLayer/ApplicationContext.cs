using DataLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : base(dbContext)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<UserQuiz>().HasKey(k => new { k.UserId, k.QuizId });
            mb.Entity<UserQuiz>().HasOne(u => u.User).WithMany(u => u.UserQuizzes).HasForeignKey(uid => uid.UserId);
            mb.Entity<UserQuiz>().HasOne(q => q.Quiz).WithMany(q => q.UserQuizzes).HasForeignKey(qid => qid.QuizId);
            mb.Entity<IdentityUserLogin<int>>().HasNoKey();
            mb.Entity<IdentityUserRole<int>>().HasNoKey();
            mb.Entity<IdentityUserToken<int>>().HasNoKey();
           
        }

    }
}
