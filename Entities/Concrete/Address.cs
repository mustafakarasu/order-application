using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Address : BaseEntity, IEntity
    {
        [Display(Name = "Adres Detayı")]
        public string AddressLine { get; set; }

        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Display(Name = "Ülke")]
        public string Country { get; set; }

        [Display(Name = "Şehir Kodu")]
        public int CityCode { get; set; }

        public Customer Customer { get; set; }
        
    }
}
