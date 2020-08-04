﻿using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public bool CheckIfQuizExisting(string name)
        {
            return db.Quizzes.Any(x => x.Name == name);
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
            return db.Quizzes.Include(x => x.Questions).FirstOrDefault(x=>x.Id==id);
        }
        public List<Quiz> GetAll()
        {
            return db.Quizzes.Include(x=>x.Questions).ThenInclude(x=>x.Answers).ToList();
        }
        public List<Question> AddQuestionForQuiz(int questionId, int quizId)
        {
            var quiz = GetById(quizId);
            var question = db.Questions.FirstOrDefault(x=>x.Id==questionId);
            quiz.Questions.Add(question);
            db.SaveChanges();
            return quiz.Questions.ToList();
            
        }
        public int Update(Quiz quiz)
        {
            db.Quizzes.Update(quiz);
            db.SaveChanges();
            return quiz.Id;
        }

    }
}
