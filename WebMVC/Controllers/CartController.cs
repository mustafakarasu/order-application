using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models.HelperModels;

namespace WebMVC.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IAddressService _addressService;
        private IProductOrderService _productOrderService;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CartController(IProductService productService, IMapper mapper, ICustomerService customerService, IOrderService orderService, IUnitOfWork unitOfWork, IAddressService addressService, IProductOrderService productOrderService)
        {
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
            _addressService = addressService;
            _productOrderService = productOrderService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string model = null;

            if (HttpContext.Session.GetString("Model") != null)
            {
                model = HttpContext.Session.GetString("Model");
            }
            else
            {
                TempData["EmptyCart"] = true;
                return RedirectToAction("Index","Home");
            }

            int totalQuantity = 0;
            OrderCartDto orderCartDto = null;

            var givenShoppingCartItems = JsonConvert.DeserializeObject<List<GivenShoppingCart>>(model.ToString());

            if (givenShoppingCartItems.Count() > 0)
            {
                orderCartDto = new OrderCartDto();

                foreach (var item in givenShoppingCartItems)
                {
                    Product product = _productService.GetById(item.Id.Value);
                    ProductCartDto productCartDto = _mapper.Map<ProductCartDto>(product);
                    product.Id = item.Id.Value;
                    productCartDto.Price = product.Price;
                    productCartDto.Quantity = item.Quantity;
                    productCartDto.TotalPrice = item.Quantity * product.Price;
                    totalQuantity = totalQuantity + item.Quantity;
                    orderCartDto.Products.Add(productCartDto);
                };

                orderCartDto.TotalQuantity = totalQuantity;
                orderCartDto.TotalAmount = orderCartDto.Products.Sum(x => x.TotalPrice);
            }
            return View(orderCartDto);
        }

        [HttpPost]
        public IActionResult Index(OrderCartDto orderCartDto)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Product> products = _mapper.Map<List<Product>>(orderCartDto.Products);
                Order order = _mapper.Map<Order>(orderCartDto);

                DateTime orderDate = DateTime.Now;

                Address address = new Address()
                {
                    AddressLine = orderCartDto.Address.AddressLine,
                    City = orderCartDto.Address.City,
                    Country = orderCartDto.Address.Country,
                    CityCode = 34
                };

                _addressService.Create(address);
                _unitOfWork.Commit();

                Customer customer = new Customer()
                {
                    Name = orderCartDto.Customer.Name,
                    Email = orderCartDto.Customer.Email,
                    CreatedAt = orderDate,
                    UpdateAt = orderDate,
                    Address = address
                };

                _customerService.Create(customer);
                _unitOfWork.Commit();

                order.Address = address;
                order.Customer = customer;
                order.CreatedAt = orderDate;
                order.UpdateAt = orderDate;
                order.Status = "Şipariş Hazırlanıyor";

                _orderService.Create(order);
                _unitOfWork.Commit();

                foreach (Product product in products)
                {
                    ProductOrder productOrder = new ProductOrder()
                    {
                        ProductId = product.Id,
                        OrderId = order.Id
                    };
                    _productOrderService.Create(productOrder);
                    _unitOfWork.Commit();
                }

                TempData["OrderCompleted"] = true;
                return RedirectToAction("Index", "Home");
            }
            return View(orderCartDto);
        }

        [HttpPost]
        public IActionResult ClearSetting(string model)
        {
            if (HttpContext.Session.GetString("Model") != null)
            {
                HttpContext.Session.Remove("Model");
            }
            HttpContext.Session.SetString("Model", model);

            var jsonResult = new
            {
                isSuccessful = true,
                redirectUrl = Url.Action("Index", "Cart")
            };

            return Json(jsonResult);
        }
    }
}
