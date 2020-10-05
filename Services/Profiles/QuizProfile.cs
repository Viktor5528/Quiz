using AutoMapper;
using DataLayer.Entity;
using Services.Requests;
using Services.ResponsesModels;

namespace Services.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<CreateQuizRequestModel, Quiz>().ReverseMap();
            CreateMap<UpdateQuizRequestModel, Quiz>().ReverseMap();
            CreateMap<ShortInfoQuizResponse, Quiz>().ReverseMap();
        }
    }
}
