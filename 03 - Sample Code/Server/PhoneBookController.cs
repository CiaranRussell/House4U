using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    [Route("api/PhoneBook")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        static List<PhoneBookEntry> _phoneBook = new List<PhoneBookEntry>()
        {
            new PhoneBookEntry(){PhoneNumber="0876555", Name="Jemmy Ned", Address="3 The Square"},
            new PhoneBookEntry(){PhoneNumber="086555555", Name="Mary Mack", Address="4 The Circle"},
            new PhoneBookEntry(){PhoneNumber="08944455555", Name="Billy McBurty", Address="Around"},
            new PhoneBookEntry(){PhoneNumber="08812345655", Name="Biddy Bad", Address="Downtown"}
        };

       
        // GET: api/<PhoneBookController>
        [HttpGet]
        public IEnumerable<PhoneBookEntry> Get()
        {
            return _phoneBook;
        }

        [HttpGet("ByName/{_name}")]
        public IEnumerable<PhoneBookEntry> GetByName(string _name)
        {
            return _phoneBook.Where(p => p.Name.Equals(_name));
        }

        
        [HttpGet("ByNumber/{_number}")]
        public PhoneBookEntry GetByNumber(string _number)
        {
            return _phoneBook.FirstOrDefault(p => p.PhoneNumber.Equals(_number));


        }

        // PUT api/<PhoneBookController>/5
        [HttpPut("{PhoneBookEntry}")]
        public ActionResult Put([FromBody] PhoneBookEntry value)
        {
           if (value == null)
           {
                return BadRequest("No data in request");
           }

            PhoneBookEntry p1 = _phoneBook.FirstOrDefault(p => p.PhoneNumber.Equals(value.PhoneNumber));
            if (p1 != null)
            {
                return BadRequest("REcord already exists");
            }

            _phoneBook.Add(value);
            return Ok("Record added");
        }
    }
}
