using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Services.Profiles;

namespace XUnitTests
{
    class AutoMapperHelper
    {
        private readonly static MapperConfiguration _mapperConfiguration;
        static AutoMapperHelper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AnswerProfile>();
                cfg.AddProfile<QuizProfile>();
                cfg.AddProfile<QuestionProfile>();
            });
        }

        public static IMapper GetMapper()
        {
            return new Mapper(_mapperConfiguration);
        }
    }
}
