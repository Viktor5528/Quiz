using AutoMapper;
using DataLayer.Entity;
using DataLayer.Enums;
using DataLayer.Repo.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;
using Services.Responses;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepo _repo;
        IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(IUserRepo repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<int> CreateAsync(RegisterViewModel model)
        {
           
            if (model.Password.Length > 20)
                throw new Exception("Password length >20");

            if (string.IsNullOrWhiteSpace(model.Login)) 
            {
                throw new Exception("Message"); 
            }
            
                User user = new User { Login = model.Login, Age = model.Age };
           
                var result = await _userManager.CreateAsync(user, model.Password);
            _repo.Save();
            return user.Id;

        }
        public int Delete(int id)
        {
            if (_repo.GetById(id) == null)
            {
                throw new Exception("User with this ID undefined");
            }
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
