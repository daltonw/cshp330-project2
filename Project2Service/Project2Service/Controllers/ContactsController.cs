using Microsoft.AspNetCore.Mvc;
using Project2Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static int currentId = 101;
        private static List<Contact> contacts = new List<Contact>();

        // GET: api/<ContactsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(contacts);
        }

        // GET: api/<ContactsController>/101
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(contact);
            }
        }

        // POST: api/Contacts
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            if (value.Email == null || value.Password == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Both Email and Password are required. " +
                              "Your add user request has failed. "  +
                              "Please try again.",
                    Email = value.Email,
                    Password = value.Password
                });
            }

            value.Id = currentId++;
            value.DateAdded = DateTime.UtcNow;
            value.DateModified = value.DateAdded;
            contacts.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);

        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            if (value.Email != null)
                contact.Email = value.Email;

            if (value.Password != null)
                contact.Password = value.Password;

            contact.DateModified = DateTime.UtcNow;

            return Ok(contact);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactsDeleted = contacts.RemoveAll(t => t.Id == id);

            if (contactsDeleted == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
