using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator: AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(a => a.FirstName).NotNull().MinimumLength(2);
            RuleFor(a => a.LastName).NotNull().MinimumLength(2);
            RuleFor(a => a.Password).NotNull().MinimumLength(5);

            

        }
          
        
    }
}
