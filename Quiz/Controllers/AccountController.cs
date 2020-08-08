using DataLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.RequestsModels;
using Services.ResponsesModels;
using Services.ViewModels;
using System;
using System.Threading.Tasks;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        IUserService _service;
        

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(model);

            }
            return Ok(model);
        }
        [HttpPost("Login")]
        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest loginRequest)
        {
           return await _service.LoginAsync(loginRequest);
        }
    }
}
