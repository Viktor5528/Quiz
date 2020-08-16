using FluentValidation;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Validators
{
    public class CreateQuestionsValidator:AbstractValidator<CreateQuestionRequestModel>
    {
        public CreateQuestionsValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Theme).Must(x => Enum.IsDefined(typeof(DataLayer.Enums.Theme), x)).WithMessage("Theme is not found");
        }
    }
}
