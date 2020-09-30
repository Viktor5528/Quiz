using AutoFixture.Xunit2;
using AutoMapper;
using DataLayer.Entity;
using DataLayer.Repo.Interfaces;
using Moq;
using Services;
using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using QuizEntity = DataLayer.Entity.Quiz;

namespace XUnitTests
{
    public class QuizTests
    {
        Mock<IQuizRepo> _mockQuiz = new Mock<IQuizRepo>();
        Mock<IQuestionRepo> _mockQuestion = new Mock<IQuestionRepo>();
        IMapper _mapper;
        QuizService _service;
        public QuizTests()
        {
            _mockQuiz.Setup(x => x.Create(It.IsAny<QuizEntity>())).Returns(Task.FromResult(1));
            _mockQuiz.Setup(x => x.CheckIfQuizExisting("name")).Returns(true);
            _mockQuiz.Setup(x => x.AddQuestionForQuiz(1, 1)).Returns(new List<Question>());
            _mockQuiz.Setup(x => x.GetById(1)).Returns(new QuizEntity());
            _mockQuestion.Setup(x => x.GetById(1)).Returns(new Question());
            _mapper = AutoMapperHelper.GetMapper();
            _service = new QuizService(_mapper, _mockQuiz.Object, _mockQuestion.Object);
        }
        [Fact]
        public async void CreateQuizValidValueTest()
        {

            var result =await  _service.Create(new CreateQuizRequestModel
            {
                Questions = new List<CreateQuestionRequestModel>(),
                Name = "123123",
                Theme = 2
            });
            Assert.Equal(1, result);
        }
        [Theory, AutoData]
        public async  void CreateQuizInvalidValue(CreateQuizRequestModel model)
        {
            model.Name = "name";
             await Assert.ThrowsAsync<Exception>(async() =>
            {
                await _service.Create(model);
            });
        }
        [Theory]
        [InlineData(2, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public void AddQuestionInvalidQuestionID(int questionId, int quizId)
        {
            Assert.Throws<Exception>(() => _service.AddQuestionForQuiz(questionId, quizId));
        }
        [Fact]
        public void AddQuestionIfQuizThemeAndQuestionThemeNotEqual()
        {
            _mockQuiz.Setup(x => x.GetById(1)).Returns(new QuizEntity()
            {
                Theme = DataLayer.Enums.Theme.It
            });
            _mockQuestion.Setup(x => x.GetById(1)).Returns(new Question()
            {
                Theme = DataLayer.Enums.Theme.Bio
            });
            //eqweqwesaddasdas
            Assert.Throws<Exception>(() => _service.AddQuestionForQuiz(1, 1));
        }
        [Fact]
        public void AddQuestionReturnValidResult()
        {
            _mockQuiz.Setup(x => x.GetById(1)).Returns(new QuizEntity()
            {
                Theme = DataLayer.Enums.Theme.Bio
            });
            _mockQuestion.Setup(x => x.GetById(1)).Returns(new Question()
            {
                Theme = DataLayer.Enums.Theme.Bio
            });
            Assert.IsType<List<ShortInfoQuestionResponse>>(_service.AddQuestionForQuiz(1, 1));
        }

    }
}
