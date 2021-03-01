﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(cı => cı.CarId).NotEmpty();
            //RuleFor(cı => cı.Date).Empty().WithMessage("Date will be determined automatically.");
            //RuleFor(cı => cı.Date).Equal(DateTime.Now);
   
        }

       
    }
}
