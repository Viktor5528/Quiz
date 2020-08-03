using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repo
{
    class QuestionsRepo : IQuestionRepo
    {
        Context db;
        public QuestionsRepo(Context context)
        {
            db = context;
        }
        public int Create(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return question.Id;
        }

        public int Delete(int id)
        {
            var question = GetById(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return question.Id;
        }
        public Question GetById(int id)
        {
            return db.Questions.Find(id);
        }
        public List<Question> GetAll()
        {
            return db.Questions.ToList();
        }

        public int Update(Question question)
        {
            db.Questions.Update(question);
            db.SaveChanges();
            return question.Id;
        }
    }
}
