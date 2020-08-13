using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;
using CsvHelper;
using System.IO;

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
        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            var stream = new MemoryStream();
            file.CopyTo(stream);
            var bytes=stream.ToArray();
            _user.Import(bytes);
            return Ok();
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
