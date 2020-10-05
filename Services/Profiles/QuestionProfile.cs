using AutoMapper;
using DataLayer.Entity;
using Services.Requests;
using Services.Responses;
using Services.ResponsesModels;

namespace Services.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionRequestModel, Question>().ReverseMap();
            CreateMap<UpdateQuestionRequestModel, Question>().ReverseMap();
            CreateMap<ShortInfoQuestionResponse, Question>().ReverseMap();
            CreateMap<QuestionResponseModel, Question>().ReverseMap();
            CreateMap<ShortInfoQuestionResponse, CreateQuestionRequestModel>().ReverseMap();
        }
    }
}
