using FluentValidation;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Validators
{
    public class CreateQuizValidator:AbstractValidator<CreateQuizRequestModel>
    {
        public CreateQuizValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 20);
            RuleFor(x => x.Theme).Must(x=>Enum.IsDefined(typeof(DataLayer.Enums.Theme),x)).WithMessage("Theme is not found");
            
        }
    }
}
