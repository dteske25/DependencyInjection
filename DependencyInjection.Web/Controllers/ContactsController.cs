using DependencyInjection.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace DependencyInjection.Web.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactsController : ApiController
    {
        private readonly ApplicationDbContext db;

        public ContactsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/contact
        [Route("")]
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        // GET: api/contact/5
        [Route("{id}")]
        public IHttpActionResult GetContact(string id)
        {
            var parsedId = int.Parse(id);
            Contact contact = db.Contacts.Find(parsedId);

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

            db.Contacts.Add(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ContactExists(contact.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(contact);
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

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(parsedId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }



        // DELETE: api/Contacts/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteContact(string id)
        {
            var parsedId = int.Parse(id);

            Contact contact = db.Contacts.Find(parsedId);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}
