using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;


namespace shopapp.webui.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; } 
        public int TotalComments { get; set; }
        public double AverageVotePoint { get; set; }

        [Required(ErrorMessage="Comment Point is required.")]
        [Range(1, 5, ErrorMessage = "Please enter a value between 1 and 20 for the integer.")]
        public int VotePoint { get; set; }

        [Required(ErrorMessage="Comment City is required.")]
        [StringLength(20,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 20 for the City.")] 
        public string CommentIcon { get; set; }
        
        [Required(ErrorMessage="Comment is required.")]
        [StringLength(250,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 250 for the Comment.")] 
        public string CommentText { get; set;}

    }
}