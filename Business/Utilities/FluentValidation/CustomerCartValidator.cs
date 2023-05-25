using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class CustomerCartValidator : AbstractValidator<Customer>
    {
        public CustomerCartValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Adınızı giriniz");
            RuleFor(x => x.Email).NotNull().WithMessage("Email adresinizi giriniz");
        }
    }
}
