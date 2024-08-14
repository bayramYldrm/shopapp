using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository=contactRepository;
        }

        public void Create(Contact entity)
        {
            _contactRepository.Create(entity);
        }

        public void Delete(Contact entity)
        {
            _contactRepository.Delete(entity);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);
        }
    }
}