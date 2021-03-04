
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).Must(NotStartZero).WithMessage("Password must not start 0.");
            RuleFor(u => u.Password).MinimumLength(5);
        }

        private bool NotStartZero(string arg)
        {
            return !arg.StartsWith("0");
        }
    }
}
