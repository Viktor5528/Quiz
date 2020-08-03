using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerService _answer;
        public AnswerController(IAnswerService answer)
        {
            _answer = answer;
        }
        [HttpPost]
        public IActionResult Create(CreateAnswerRequestModel model)
        {
            return Ok(_answer.Create(model));

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_answer.GetAll());
        }
        [HttpPut]
        public IActionResult Update(UpdateAnswerRequestModel model)
        {
            return Ok(_answer.Update(model));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_answer.Delete(id));
        }
    }
}
