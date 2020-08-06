using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;

        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_user.GetAll());
        }
        [HttpPut]
        public IActionResult Update(UpdateUserRequestModel model)
        {
            return Ok(_user.Update(model));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_user.Delete(id));
        }

    }
}
