using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCommentRepository : EfCoreGenericRepository<Comment, ShopContext>, ICommentRepository
    {

        public List<Comment> GetCommentsByProductId(int productId)
        {
            using(var context = new ShopContext())
            {
                return context.Comments
                                    .Where(c => c.ProductId == productId)
                                    .ToList();
            }
        }
    }
}