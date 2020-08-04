using AutoMapper;
using DataLayer.Entity;
using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiles
{
    public class AnswerProfile:Profile
    {
        public AnswerProfile()
        {
            CreateMap<CreateAnswerRequestModel, Answer>();
            CreateMap<UpdateAnswerRequestModel, Answer>();
            CreateMap<ShortInfoAnswerResponse, Answer>().ReverseMap();
        }
    }
}
