using DependencyInjection.Core.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DependencyInjection.Accessors
{
    public class ContactsAccessor : DbContext, IDisposable
    {
        private DbSet<Contact> Contacts { get; set; }

        public ContactsAccessor() : base("name=ApplicationDbContext")
        {
            Contacts = Set<Contact>();
        }

        public IQueryable<Contact> GetAll()
        {
            return Contacts;
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Insert(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact contact)
        {
            Entry(contact).State = EntityState.Modified;
        }

        public Contact Delete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            return Contacts.Any(c => c.Id == id);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
