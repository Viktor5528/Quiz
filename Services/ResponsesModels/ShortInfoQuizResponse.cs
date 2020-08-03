using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ResponsesModels
{
    class ShortInfoQuizResponse
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
