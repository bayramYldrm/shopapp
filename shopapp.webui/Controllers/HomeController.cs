using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.webui.Extensions;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController:Controller
    {      
        private IProductService _productService;
        private IContactService _contactService;
        
        public HomeController(IProductService productService, IContactService contactService)
        {
            this._productService=productService;
            this._contactService=contactService;
        }
        
        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };

            return View(productViewModel);
        }

        public IActionResult About()
        {
            return View("About");
        }

         public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Stores()
        {
            return View("Stores");
        }
            
        public IActionResult ContactCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactCreate(ContactModel model)
        {
             if(ModelState.IsValid)
            {
                var entity = new Contact()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message           
                };
                
                _contactService.Create(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title="Message added.",
                    Message=$"{entity.Name}  Your message has been added.",
                    AlertType="success"
                });             

                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}