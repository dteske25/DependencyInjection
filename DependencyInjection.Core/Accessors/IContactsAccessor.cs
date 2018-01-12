using DependencyInjection.Core.Models;
using System.Linq;

namespace DependencyInjection.Core.Accessors
{
    public interface IContactsAccessor
    {
        IQueryable<Contact> GetAll();
        Contact Find(int id);
        Contact Insert(Contact contact);
        void Update(Contact contact);
        Contact Delete(Contact contact);
        bool Exists(int id);
        int SaveChanges();
    }
}
