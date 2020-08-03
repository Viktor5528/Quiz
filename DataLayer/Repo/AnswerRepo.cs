using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repo
{
    public class AnswerRepo : IAnswerRepo
    {
        Context db;
        public AnswerRepo(Context context)
        {
            db = context;
        }
        public int Create(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
            return answer.Id;
        }
        public Answer GetById(int id)
        {
            return db.Answers.Find(id);
        }
        public int Delete(Answer answer)
        {
            db.Answers.Remove(answer);
            db.SaveChanges();
            return answer.Id;
        }
        public List<Answer> GetAllCorrectAnswerForQuiz(int id)
        {
            var answers = db.Quizzes.Include(o => o.Questions).ThenInclude(p => p.Answers)
                            .FirstOrDefault(x => x.Id == id)?.Questions.SelectMany(x => x.Answers)
                            .Where(x => x.IsCorrect);
            return answers?.ToList();

        }
        public List<Answer> GetAll()
        {
            return db.Answers.ToList();
        }

        public int Update(Answer answer)
        {
            db.Answers.Update(answer);
            db.SaveChanges();
            return answer.Id;
        }
    }
}
