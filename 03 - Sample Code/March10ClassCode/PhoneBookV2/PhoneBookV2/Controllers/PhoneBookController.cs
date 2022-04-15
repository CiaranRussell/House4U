using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBookV2.Data;

namespace PhoneBookV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookV2Context _context;

        public PhoneBookController(PhoneBookV2Context context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/PhoneBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneBookEntry>>> GetPhoneBookEntry()
        {
            return await _context.PhoneBookEntry.ToListAsync();
        }

        // GET: api/PhoneBook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneBookEntry>> GetPhoneBookEntry(int id)
        {
            var phoneBookEntry = await _context.PhoneBookEntry.FindAsync(id);

            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            return phoneBookEntry;
        }

        // PUT: api/PhoneBook/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneBookEntry(int id, PhoneBookEntry phoneBookEntry)
        {
            if (id != phoneBookEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneBookEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PhoneBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneBookEntry>> PostPhoneBookEntry(PhoneBookEntry phoneBookEntry)
        {
            _context.PhoneBookEntry.Add(phoneBookEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneBookEntry", new { id = phoneBookEntry.Id }, phoneBookEntry);
        }

        // DELETE: api/PhoneBook/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneBookEntry(int id)
        {
            var phoneBookEntry = await _context.PhoneBookEntry.FindAsync(id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            _context.PhoneBookEntry.Remove(phoneBookEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneBookEntryExists(int id)
        {
            return _context.PhoneBookEntry.Any(e => e.Id == id);
        }
    }
}
