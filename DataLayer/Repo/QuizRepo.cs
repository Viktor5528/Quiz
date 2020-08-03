using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repo
{
    public class QuizRepo : IQuizRepo
    {
        Context db;
        public QuizRepo(Context context)
        {
            db = context;
        }

        public int Create(Quiz quiz)
        {
            db.Quizzes.Add(quiz);
            db.SaveChanges();
            return quiz.Id;
        }

        public int Delete(int id)
        {
            var quiz = GetById(id);
            db.Quizzes.Remove(quiz);
            db.SaveChanges();
            return quiz.Id;
        }
        public Quiz GetById(int id)
        {
            return db.Quizzes.Find(id);
        }
        public List<Quiz> GetAll()
        {
            return db.Quizzes.ToList();
        }

        public int Update(Quiz quiz)
        {
            db.Quizzes.Update(quiz);
            db.SaveChanges();
            return quiz.Id;
        }

    }
}
