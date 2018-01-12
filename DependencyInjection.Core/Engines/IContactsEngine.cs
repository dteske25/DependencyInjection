using DependencyInjection.Core.Models;
using System.Collections.Generic;

namespace DependencyInjection.Core.Engines
{
    public interface IContactsEngine
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int id);
        Contact InsertContact(Contact newContact);
        Contact UpdateContact(int id, Contact updated);
        Contact DeleteContact(int id);
    }
}
