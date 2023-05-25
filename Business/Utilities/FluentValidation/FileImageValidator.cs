using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class FileImageValidator : AbstractValidator<IFormFile>
    {
        public FileImageValidator()
        {
            RuleFor(x => x.Length).GreaterThan(0).WithMessage("Dosya yükleyiniz");

            RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("İzin verilen türde dosya yükletyiniz (.png, .jpg, .jpeg)");
        }
    }
}
