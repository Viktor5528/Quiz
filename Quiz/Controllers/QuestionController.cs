using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService _question;
        public QuestionController(IQuestionService question)
        {
            _question = question;
        }
        [HttpPost]
        public int Create(CreateQuestionRequestModel model)
        {
            return _question.Create(model);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_question.GetAll());
        }
        [HttpPut]
        public IActionResult Update(UpdateQuestionRequestModel model)
        {
            return Ok(_question.Update(model));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_question.Delete(id));
        }
    }
}
