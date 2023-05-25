using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class AddressCartValidator : AbstractValidator<Address>
    {
        public AddressCartValidator()
        {
            RuleFor(x => x.AddressLine).NotNull().WithMessage("Adres Detayını giriniz");
            RuleFor(x => x.City).NotNull().WithMessage("Şehir alanını giriniz");
            RuleFor(x => x.Country).NotNull().WithMessage("Ülke alanını giriniz");
        }
    }
}
