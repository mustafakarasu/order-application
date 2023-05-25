using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class OrderCartDto
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public List<ProductCartDto> Products { get; set; }

        [Display(Name = "Toplam Ürün Adeti")]
        public int TotalQuantity { get; set; }

        [Display(Name = "Toplam Tutar")]
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public OrderCartDto()
        {
            Products = new List<ProductCartDto>();
        }
    }
}
