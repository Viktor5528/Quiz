using AutoMapper;
using DataLayer.Entity;
using DataLayer.Enums;
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
        public int Delete(User user)
        {
            _repo.Delete(user);
            return user.Id;
        }
        public int Update(User user)
        {
            _repo.Update(user);

            return user.Id;
        }
        public Role GetRole(User user)
        {
            return user.Role;
        }
        public List<ShortInfoUserResponse> GetAll()
        {
            return _mapper.Map<List<ShortInfoUserResponse>>(_repo.GetAll());
        }


    }
}
