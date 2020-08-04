using AutoMapper;
using DataLayer.Entity;
using DataLayer.Enums;
using DataLayer.Migrations;
using DataLayer.Repo.Interfaces;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using System.Collections.Generic;
using Theme = DataLayer.Enums.Theme;

namespace Services
{
    public class QuestionService : IQuestionService
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
            question.Theme = (Theme)model.Theme;
            return _repo.Update(question);
        }
        public List<ShortInfoQuestionResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoQuestionResponse>>(_repo.GetAll());
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
