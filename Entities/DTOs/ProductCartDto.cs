using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class ProductCartDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Ürün Fotoğrafı")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public double Price { get; set; }

        [Display(Name = "Toplam Fiyat")]
        public double TotalPrice { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
