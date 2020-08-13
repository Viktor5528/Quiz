using AutoMapper;
using CsvHelper;
using DataLayer.Entity;
using DataLayer.Enums;
using DataLayer.Repo.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;
using Services.RequestsModels;
using Services.Responses;
using Services.ResponsesModels;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepo _repo;
        ITokenService _token;
        IMapper _mapper;
        private readonly UserManager<User> _userManager;
        
        public UserService(IUserRepo repo, IMapper mapper, UserManager<User> userManager, ITokenService token)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _token = token;
        }
        public async Task Import(byte[] file)
        {
            using (Stream stream = new MemoryStream(file))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<CSVUser>();
                var records = csv.GetRecords<RegisterViewModel>();
                foreach( var a in records)
                {
                   await CreateAsync(a);
                }
            }
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
            await _userManager.CreateAsync(user, model.Password);
            _repo.Save();
            return user.Id;

        }
        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                throw new Exception("Username or password is incorrect");
            }

            return new UserLoginResponse
            {
                Token = _token.GenerateToken(user)
            };
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
