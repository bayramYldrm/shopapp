using System.Collections.Generic;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Delete(Contact entity);
        void Create(Contact entity);
    }
}