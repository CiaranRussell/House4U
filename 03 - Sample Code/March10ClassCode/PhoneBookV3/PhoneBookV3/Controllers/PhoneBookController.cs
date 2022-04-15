using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBookV3.Data;

namespace PhoneBookV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookV3Context _context;

        public PhoneBookController(PhoneBookV3Context context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/PhoneBook
        [HttpGet]
        public IEnumerable<PhoneBookEntry> GetPhoneBookEntry()
        {
            return _context.PhoneBookEntry.ToList();
        }

        // GET: api/PhoneBook/5
        [HttpGet("{id}")]
        public PhoneBookEntry GetPhoneBookEntry(string id)
        {
            var phoneBookEntry = _context.PhoneBookEntry.Find(id);

            if (phoneBookEntry == null)
            {
                return null;
            }

            return phoneBookEntry;
        }

        // PUT: api/PhoneBook/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPhoneBookEntry(string id, PhoneBookEntry phoneBookEntry)
        {
            if (id != phoneBookEntry.PhoneNumber)
            {
                return BadRequest();
            }

            _context.Entry(phoneBookEntry).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest("Failed to save to DB");
            }

            return NoContent();
        }

        // POST: api/PhoneBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostPhoneBookEntry(PhoneBookEntry phoneBookEntry)
        {
            _context.PhoneBookEntry.Add(phoneBookEntry);
            try
            {
                 _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("Failed to save to DB!");
            }
            return Ok("Record Updated");
        }

        // DELETE: api/PhoneBook/5
        [HttpDelete("{id}")]
        public IActionResult DeletePhoneBookEntry(string id)
        {
            var phoneBookEntry =  _context.PhoneBookEntry.Find(id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            _context.PhoneBookEntry.Remove(phoneBookEntry);
             _context.SaveChanges();

            return NoContent();
        }

        private bool PhoneBookEntryExists(string id)
        {
            return _context.PhoneBookEntry.Any(e => e.PhoneNumber == id);
        }
    }
}
