using DependencyInjection.Core.Accessors;
using DependencyInjection.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.BusinessLogic.Tests.MockedAccessors
{
    public class MockedContactsAccessor : IContactsAccessor
    {
        private List<Contact> contacts;

        public MockedContactsAccessor()
        {
            contacts = new List<Contact>();
        }

        public Contact Delete(Contact contact)
        {
            contacts.Remove(contact);
            return contact;
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            return contact;
        }

        public IQueryable<Contact> GetAll()
        {
            return contacts.AsQueryable();
        }

        public Contact Insert(Contact contact)
        {
            var max = contacts.Max(c => c.Id);
            contact.Id = max + 1;
            contacts.Add(contact);
            return contact;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Update(Contact contact)
        {
            contacts.RemoveAll(c => c.Id == contact.Id);
            contacts.Add(contact);
        }


        /// <summary>
        /// This is a method added to the mocked accessor to 
        /// easily get the underlying state back out.
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetState()
        {
            return contacts;
        }

        /// <summary>
        /// This is a method added to the mocked accessor to
        /// easily set the underlying state.
        /// </summary>
        /// <param name="newState"></param>
        public void SetState(List<Contact> newState)
        {
            contacts = newState;
        }

    }
}
