using FluentValidation;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Validators
{
    public class CreateAnswerValidator : AbstractValidator<CreateAnswerRequestModel>
    {
        public CreateAnswerValidator()
        {
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
