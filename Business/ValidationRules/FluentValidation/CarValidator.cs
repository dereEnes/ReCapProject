using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Ücret 0 dan büyük olmalı");
            RuleFor(c => c.Description).MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.ModelYear).GreaterThan(1950).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(c => c.ColorId).GreaterThanOrEqualTo(1);
            RuleFor(c => c.BrandId).GreaterThanOrEqualTo(1);
        }
    }
}
