using AutoMapper;
using ClosedXML.Excel;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using Services.Requests;
using Services.RequestsModels;
using Services.Responses;
using Services.ResponsesModels;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task Import(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheets.First();
            try
            {
                for (int i = 1; true; i++)
                {
                    var model = new RegisterRequesteModel
                    {
                        Login = worksheet.Cell(i + 1, 1).Value.ToString(),
                        Password = worksheet.Cell(i + 1, 2).Value.ToString(),
                        Age = Convert.ToInt32(worksheet.Cell(i + 1, 3).Value)
                    };
                    await CreateAsync(model);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public byte[] Export()
        {
            var users = _repo.GetAll();
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Users");
            worksheet.Cell(1, 1).Value = "Login";
            worksheet.Cell(1, 2).Value = "Age";
            for (int i = 1; i <= users.Count; i++)
            {
                worksheet.Cell(i + 1, 1).Value = users[i - 1].Login;
                worksheet.Cell(i + 1, 2).Value = users[i - 1].Age;
            }
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }

        }
        public async Task<int> CreateAsync(RegisterRequesteModel model)
        {

            if (model.Password.Length > 20)
                throw new Exception("Password length >20");

            if (string.IsNullOrWhiteSpace(model.Login))
            {
                throw new Exception("Login is incorrect");
            }

            User user = new User { Login = model.Login, Age = model.Age };
            await _userManager.CreateAsync(user, model.Password);
            _repo.Save();
            return user.Id;

        }
        public async Task<UserLoginResponse> LoginAsync(LoginRequestModel loginRequest)
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
