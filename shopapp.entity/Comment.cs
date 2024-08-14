using System;


namespace shopapp.entity
{
    public class Comment
    {
        public int CommentId { get; set;}
        public string CommentText { get; set;}
        public int ProductId { get; set;}
        public Product product { get; set; }
        public string UserName { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public DateTime CommentDate { get; set; }
        public string CommentIcon { get; set; }
        public int VotePoint { get; set; }
    }
}