using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICommentRepository: IRepository<Comment>
    {
        List<Comment> GetCommentsByProductId(int productId);
    }
}