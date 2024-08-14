using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }  
        public string Name { get; set; }     
       
        [Required(ErrorMessage="URL is a required field.")]  
        public string Url { get; set; }     
        public double? Price { get; set; } 
      
        [Required(ErrorMessage="Description is required.")]
        [StringLength(10000,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 10000 for the Description.")]
        public string Description { get; set; }      
       
        [Required(ErrorMessage="Image Url is required.")]  
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string Location { get; set; }
        public DateTime LastStockChange { get; set; }
        public int StockQuantity { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}