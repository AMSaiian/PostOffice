using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class AuthModelValidator : AbstractValidator<AuthModel>
    {
        public AuthModelValidator()
        {
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Matches(@"^\+380\d{9}$");;
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
