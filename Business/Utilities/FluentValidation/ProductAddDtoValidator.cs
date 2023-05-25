using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Lütfen Ürün Fiyatını Giriniz");
            RuleFor(x => x.Name).NotNull().WithMessage("Ürün Adı girmelisiniz");
            RuleFor(x => x.ImageFile).SetValidator(new FileImageValidator());
        }
    }
}
