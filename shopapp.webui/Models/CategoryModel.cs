using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
                
        [Required(ErrorMessage="The category name is required.")]
        [StringLength(100,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 100 for the category.")]        
        public string Name { get; set; }

        [Required(ErrorMessage="The URL is required.")]
        [StringLength(100,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 100 for the URL.")]        
        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}