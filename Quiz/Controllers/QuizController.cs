using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Services.Interfaces;
using Services.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        public async Task<int> Create(CreateQuizRequestModel model)
        {
            return await _quiz.Create(model);

        }
        [HttpPost("Add")]
        public IActionResult AddQuestionForQuiz([Required]int questionId, int quizId)
        {
            return Ok(_quiz.AddQuestionForQuiz(questionId, quizId));
        }
        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetAll()
        {
            return Ok(_quiz.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            try{
                return Ok(_quiz.GetById(id)); 
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpPut]
        public IActionResult Update(UpdateQuizRequestModel model)
        {
            return Ok(_quiz.Update(model));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return  Ok(await _quiz.Delete(id));
        }
    }
}
