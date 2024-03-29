﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.ImagePath).NotEmpty();
            RuleFor(p => p.ImagePath).NotNull();
        }
    }
}
