using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class ProductCartDtoValidator : AbstractValidator<ProductCartDto>
    {
        public ProductCartDtoValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Lütfen Ürün Fiyatını Giriniz");
            RuleFor(x => x.Name).NotNull().WithMessage("Ürün Adı girmelisiniz");
            RuleFor(x => x.ImageFile).SetValidator(new FileImageValidator());
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Ürün Miktarı sıfırdan büyük olmalıdır!");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Toplam Ürün Fiyatı sıfırdan büyük olmalıdır!");
        }
    }
}
