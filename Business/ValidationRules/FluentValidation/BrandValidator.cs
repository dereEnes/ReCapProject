using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2).WithMessage("2 karakterden uzun olmalı");
            

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
