using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(p => p.CardNo).Length(16).WithMessage("geçersiz cart numarası");
            RuleFor(p => p.CvCode).LessThan(1000).GreaterThanOrEqualTo(0).NotEmpty().WithMessage("Geçersiz Cvc Kodu");
            RuleFor(p => p.ExpityMonth).GreaterThanOrEqualTo(1).LessThanOrEqualTo(12).WithMessage("geçersiz son kullanma ayı");
            RuleFor(p => p.ExpityYear).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99).WithMessage("Geçersiz Son kulllanma yılı");
        }
    }
}
