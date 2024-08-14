using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace shopapp.webui.Models
{
    public class CommentModel
    {
        public int CommentId { get; set;}

        [Required(ErrorMessage="Comment is required.")]
        [StringLength(250,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 250 for the Comment.")] 
        public string CommentText { get; set;}

        public int ProductId { get; set;}
        public ProductModel product { get; set; }

        public string UserName { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public UserDetailsModel userDetailsModel { get; set; }

        public DateTime CommentDate { get; set; }

        [Required(ErrorMessage="Comment City is required.")]
        [StringLength(20,MinimumLength=5,ErrorMessage="Please enter a value between 5 and 20 for the City.")] 
        public string CommentIcon { get; set; }

        [Required(ErrorMessage="Comment Point is required.")]
        [Range(1, 5, ErrorMessage = "Please enter a value between 1 and 20 for the integer.")]
        public int VotePoint { get; set; }
    }
}