using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class OrderCartValidator : AbstractValidator<OrderCartDto>
    {
        public OrderCartValidator()
        {
            RuleForEach(x => x.Products).SetValidator(new ProductCartDtoValidator());
            RuleFor(x => x.Address).SetValidator(new AddressCartValidator());
            RuleFor(x => x.Customer).SetValidator(new CustomerCartValidator());
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Şipariş Toplamı sıfırdan büyük olmalıdır!");
            RuleFor(x => x.TotalQuantity).GreaterThan(0).WithMessage("Toplam Miktar sıfırdan büyük olmalıdır!");
        }
    }
}
