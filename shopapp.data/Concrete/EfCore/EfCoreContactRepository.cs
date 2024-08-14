using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreContactRepository : EfCoreGenericRepository<Contact, ShopContext>, IContactRepository
    {

    }
}