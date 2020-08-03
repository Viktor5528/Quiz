using AutoMapper;
using DataLayer.Entity;
using Services.Requests;

namespace Services.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<CreateQuizRequestModel, Quiz>();
        }
    }
}
