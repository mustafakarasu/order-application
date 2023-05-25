using AutoMapper;
using Business.Abstract;
using Business.Utilities.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IHostingEnvironment _environment;

        public ProductController(IProductService productService, IMapper mapper, IHostingEnvironment environment, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _mapper = mapper;
            _environment = environment;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddDto productAddDto, IFormFile ImageFile)
        {
            var validator = new ProductAddDtoValidator();
            var result = validator.Validate(productAddDto);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, null);
                return View(productAddDto);
            }

            productAddDto.ImageUrl = UploadImage();

            Product product = _mapper.Map<Product>(productAddDto);
            _productService.Create(product);

            bool resultCommit = _unitOfWork.CommitAsync().Result;

            if (resultCommit)
            {
                TempData["ProductAdded"] = true;
                return Redirect("/Home/Index");
            }
            else
            {
                return View(productAddDto);
            }
        }

        [NonAction]
        private string UploadImage()
        {
            var newFileName = string.Empty;
            string PathDb = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var myUniqueFileName = Guid.NewGuid().ToString();

                        var FileExtension = Path.GetExtension(fileName);

                        newFileName = myUniqueFileName + Convert.ToString(Guid.NewGuid()).Substring(0,7) + FileExtension;

                        var folderPath = Path.Combine(_environment.WebRootPath, "images/products");

                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        fileName = Path.Combine(folderPath + $@"/{newFileName}");

                        PathDb = "images/products/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }

            return PathDb;
        }
    }
}
