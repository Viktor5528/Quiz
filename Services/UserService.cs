using AutoMapper;
using DataLayer.Entity;
using DataLayer.Enums;
using DataLayer.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using System;
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
            if (!Enum.IsDefined(typeof(Role), model.Role))
            {
                throw new Exception("Role undefined");
            }
            if (model.Password.Length > 20)
                throw new Exception("Password length >20");

            return  string.IsNullOrWhiteSpace(model.Login)
                ? throw new Exception("Message") 
                :_repo.Create(_mapper.Map<User>(model));

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
