using DependencyInjection.BusinessLogic.Tests.MockedAccessors;
using DependencyInjection.Core.Engines;
using DependencyInjection.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.BusinessLogic.Tests
{
    [TestClass]
    public class ContactsEngineTests
    {
        private readonly IContactsEngine _contactsEngine;
        private readonly MockedContactsAccessor _mockedContactsAccessor;

        public ContactsEngineTests()
        {
            // Notice how we can sub in a fake accessor to run tests with,
            // one that we know works for sure and doesn't have to use a database
            _mockedContactsAccessor = new MockedContactsAccessor();
            _contactsEngine = new ContactsEngine(_mockedContactsAccessor);
        }

        [TestMethod]
        public void ContactsEngine_GetAllContacts()
        {
            // Set up our mocked accessor with some test data
            SeedContacts();

            // Use the engine method that you're testing
            var result = _contactsEngine.GetContacts();

            // Compare properties to ensure the engine is working correctly, and
            // verify correctness of data. I'm searching the return list to 
            // make sure that a contact with the last name of "Teske" is returned
            var contact1 = result.FirstOrDefault(c => c.LastName == "Teske");

            // There should be two entries returned to us
            Assert.AreEqual(2, result.Count());

            // Check properties about my contact
            Assert.AreEqual(1, contact1.Id);
            Assert.AreEqual("Daric", contact1.FirstName);
            Assert.AreEqual("tesked@outlook.com", contact1.EmailAddress);
        }


        [TestMethod]
        public void ContactsEngine_InsertContact()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ContactsEngine_UpdateContact()
        {
            throw new NotImplementedException();
        }


        public void SeedContacts()
        {
            _mockedContactsAccessor.SetState(new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "Daric",
                    LastName = "Teske",
                    EmailAddress = "tesked@outlook.com",
                    PhoneNumber = "1234567890"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Cooper",
                    LastName = "Knaak",
                    EmailAddress = "cooperknaak@gmail.com",
                    PhoneNumber = "0987654321"
                }
            });
        }
    }
}
