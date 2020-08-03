using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        IQuizService _quiz;
        public QuizController(IQuizService quiz)
        {
            _quiz = quiz;
        }
        [HttpPost]
        public int Create(CreateQuizRequestModel model)
        {
            return _quiz.Create(model);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_quiz.GetAll());
        }
        [HttpPut]
        public IActionResult Update(UpdateQuizRequestModel model)
        {
            return Ok(_quiz.Update(model));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_quiz.Delete(id));
        }
    }
}
