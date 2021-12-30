using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UpdateBrandValidator: AbstractValidator<UpdateBrandModel>
    {
        public UpdateBrandValidator()
        {
            RuleFor(brand => brand.Name).MinimumLength(2).WithMessage("Brand name length mush be greater than 2");
            RuleFor(brand => brand.Name).MaximumLength(20).WithMessage("Brand name length mush be less than 20");
        }
    }
}
