using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using Services.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class QuizService : IQuizService
    {
        IQuizRepo _quizRepo;
        IQuestionRepo _questionRepo;
        IMapper _mapper;

        public QuizService(IMapper mapper, IQuizRepo repo, IQuestionRepo questionRepo)
        {
            _mapper = mapper;
            _quizRepo = repo;
            _questionRepo = questionRepo;
        }
        public async Task<int> Create(CreateQuizRequestModel model)
        {

            if (_quizRepo.CheckIfQuizExisting(model.Name))
            {
                throw new Exception("Duplicated Quiz Name");
            }

            return await _quizRepo.Create(_mapper.Map<Quiz>(model));
        }
        public List<ShortInfoQuestionResponse> AddQuestionForQuiz(int questionId, int quizId)
        {
            var question = _questionRepo.GetById(questionId) ?? throw new Exception("Question not found");
            var quiz = _quizRepo.GetById(quizId) ?? throw new Exception("Quiz not found");

            if (question.Theme == quiz.Theme)
            {
                return _mapper
              .Map<List<ShortInfoQuestionResponse>>(_quizRepo.AddQuestionForQuiz(questionId, quizId));
            }
            throw new Exception("Quiz and Question have different themes");


        }



        public Task<int> Delete(int id)
        {
            return _quizRepo.Delete(id);
        }
        public int Update(UpdateQuizRequestModel model)
        {
            var quiz = _quizRepo.GetById(model.Id);
            quiz.Name = model.Name;
            quiz.Questions = model.Questions;
            return _quizRepo.Update(_mapper.Map<Quiz>(model));
        }
        public List<ShortInfoQuizResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoQuizResponse>>(_quizRepo.GetAll());
        }
    }
}
