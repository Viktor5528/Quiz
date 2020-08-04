using AutoMapper;
using DataLayer.Entity;
using Services.Requests;
using Services.Responses;
using Services.ResponsesModels;

namespace Services.Profiles
{
    class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionRequestModel, Question>();
            CreateMap<UpdateQuestionRequestModel, Question>();
            CreateMap<ShortInfoQuestionResponse, Question>().ReverseMap();
            CreateMap<QuestionResponseModel, Question>().ReverseMap();
            CreateMap<ShortInfoQuestionResponse, CreateQuestionRequestModel>().ReverseMap();
        }
    }
}
