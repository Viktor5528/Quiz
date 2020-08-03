using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Services.Requests;
using Services.ResponsesModels;
using System.Collections.Generic;

namespace Services
{
    class QuizService
    {
        IQuizRepo _repo;
        IMapper _mapper;
        public QuizService(IMapper mapper, IQuizRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public int Create(CreateQuizRequestModel model)
        {
            return _repo.Create(_mapper.Map<Quiz>(model));
        }
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
        public int Update(UpdateQuizRequestModel model)
        {
            var quiz = _repo.GetById(model.Id);
            quiz.Name = model.Name;
            quiz.Questions = model.Questions;
            return _repo.Update(_mapper.Map<Quiz>(model));
        }
        public List<ShortInfoQuizResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoQuizResponse>>(_repo.GetAll());
        }
    }
}
