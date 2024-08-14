using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class CommentListViewModel
    {
        public int ProductId { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}