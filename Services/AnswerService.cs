using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class AnswerService
    {
        IMapper _mapper;
        IAnswerRepo _repo;
        public AnswerService(IMapper mapper, IAnswerRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public int Create(CreateAnswerRequestModel model)
        {
            return _repo.Create(_mapper.Map<Answer>(model));
        }
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
        public int Update(UpdateAnswerRequestModel model)
        {
            var answer = _repo.GetById(model.Id);
            answer.Text = model.Text;
            return _repo.Update(answer);
        }
        public List<ShortInfoAnswerResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoAnswerResponse>>(_repo.GetAll());
        }
    }
}
