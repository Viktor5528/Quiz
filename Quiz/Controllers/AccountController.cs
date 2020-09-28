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
        public async Task<IActionResult> Register(RegisterRequesteModel model)
        {

            try
            { 
                return Ok(await _service.CreateAsync(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel loginRequest)
        {
            try
            {
                return Ok(await _service.LoginAsync(loginRequest));
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
