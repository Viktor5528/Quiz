using DataLayer.Enums;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ResponsesModels
{
    public class QuestionResponseModel
    {
        public string Text { get; set; }
        public bool Complexity { get; set; }
        public List<ShortInfoAnswerResponse> Answers { get; set; }
        public int Theme { get; set; }
    }
}
