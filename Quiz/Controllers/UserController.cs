using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;
using System.IO;
using System.Threading.Tasks;

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
        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            var stream = new MemoryStream();
            file.CopyTo(stream);
            await _user.Import(stream.ToArray());
            return Ok();
        }
        [HttpPost("Export")]
        public IActionResult Export()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "results.xlsx";
            return File(_user.Export(), contentType, fileName);
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
