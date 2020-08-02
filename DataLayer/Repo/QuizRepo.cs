using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repo
{
    class QuizRepo : IQuizRepo
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

        public int Delete(Quiz quiz)
        {
            db.Quizzes.Remove(quiz);
            db.SaveChanges();
            return quiz.Id;
        }

        public List<Quiz> GetAll()
        {
            return db.Quizzes.ToList();
        }
        public List<Question> GettAllQuestions(Quiz quiz)
        {
            return quiz.Questions;
        }
        public int Update(Quiz quiz)
        {
            db.Quizzes.Update(quiz);
            db.SaveChanges();
            return quiz.Id;
        }
    }
}
