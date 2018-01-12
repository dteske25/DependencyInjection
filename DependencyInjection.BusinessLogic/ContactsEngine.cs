using DependencyInjection.Accessors;
using DependencyInjection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.BusinessLogic
{
    public class ContactsEngine
    {
        private readonly ContactsAccessor _contactsAccessor;

        public ContactsEngine()
        {
            _contactsAccessor = new ContactsAccessor();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contactsAccessor.GetAll().ToList();
        }

        public Contact GetContact(int id)
        {
            if (_contactsAccessor.Exists(id))
            {
                return _contactsAccessor.Find(id);
            }
            return null;

        }

        public Contact InsertContact(Contact newContact)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateContact(int id, Contact updated)
        {
            throw new NotImplementedException();
        }

        public Contact DeleteContact(int id)
        {
            var contact = _contactsAccessor.Find(id);
            if (contact != null)
            {
                _contactsAccessor.Delete(contact);
                _contactsAccessor.SaveChanges();
            }
            return contact;
        }
    }
}
