using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepo _repo;
        IMapper _mapper;
        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public int Create(CreateUserRequestModel model)
        {
            return _repo.Create(_mapper.Map<User>(model));

        }
        public int Delete(int id)
        {
            return _repo.Delete(id);

        }
        public int Update(UpdateUserRequestModel model)
        {
            var user = _repo.GetById(model.Id);
            user.Age = model.Age;
            user.Login = model.Name;
            return _repo.Update(user);
        }

        public List<ShortInfoUserResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoUserResponse>>(_repo.GetAll());
        }


    }
}
