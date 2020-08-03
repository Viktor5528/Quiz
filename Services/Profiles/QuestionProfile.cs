using AutoMapper;
using DataLayer.Entity;
using Services.Requests;

namespace Services.Profiles
{
    class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionRequestModel, Question>();
        }
    }
}
