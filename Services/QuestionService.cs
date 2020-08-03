using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services
{
    class QuestionService : IQuestionService
    {
        IQuestionRepo _repo;
        IMapper _mapper;
        public QuestionService(IMapper mapper, IQuestionRepo repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public int Create(CreateQuestionRequestModel model)
        {
            return _repo.Create(_mapper.Map<Question>(model));
        }
        public int Update(UpdateQuestionRequestModel model)
        {
            var question = _repo.GetById(model.Id);
            question.Text = model.Text;
            question.Complexity = model.Complexity;
            return _repo.Update(question);
        }
        public List<ShortInfoQuestionResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoQuestionResponse>>(_repo.GetAll());
        }
    }
}
