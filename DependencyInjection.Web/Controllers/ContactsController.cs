using DependencyInjection.Core.Engines;
using DependencyInjection.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace DependencyInjection.Web.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactsController : ApiController
    {
        // private readonly ApplicationDbContext db;
        private readonly IContactsEngine _contactsEngine;

        public ContactsController(IContactsEngine contactsEngine)
        {
            // db = new ApplicationDbContext();
            _contactsEngine = contactsEngine;
        }

        // GET: api/contact
        [Route("")]
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            // return db.Contacts;
            return _contactsEngine.GetContacts();
        }

        // GET: api/contact/5
        [Route("{id}")]
        public IHttpActionResult GetContact(string id)
        {
            var parsedId = int.Parse(id);
            // Contact contact = db.Contacts.Find(parsedId);
            var contact = _contactsEngine.GetContact(parsedId);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST: api/Contacts
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // db.Contacts.Add(contact);
            var result = _contactsEngine.InsertContact(contact);
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (ContactExists(contact.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Ok(result);
        }

        // PUT: api/Contacts/5
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult PutContact(string id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parsedId = int.Parse(id);

            if (parsedId != contact.Id)
            {
                return BadRequest();
            }

            //db.Entry(contact).State = EntityState.Modified;
            _contactsEngine.UpdateContact(parsedId, contact);
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ContactExists(parsedId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }



        // DELETE: api/Contacts/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteContact(string id)
        {
            var parsedId = int.Parse(id);
            var contact = _contactsEngine.DeleteContact(parsedId);
            //Contact contact = db.Contacts.Find(parsedId);
            //if (contact == null)
            //{
            //    return NotFound();
            //}

            //db.Contacts.Remove(contact);
            //db.SaveChanges();

            return Ok(contact);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ContactExists(int id)
        //{
        //    return db.Contacts.Count(e => e.Id == id) > 0;
        //}
    }
}