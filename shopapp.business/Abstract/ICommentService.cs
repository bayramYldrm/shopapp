using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICommentService: IValidator<Comment>
    {
        Comment GetById(int id);
        List<Comment> GetAll();
        List<Comment> GetCommentsByProductId(int productId);
        void Create(Comment entity);
        void Delete(Comment entity);
    }
}