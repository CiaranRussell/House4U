using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookAPI : ControllerBase
    {
        static List<PhoneBookEntry> _phonebook = new List<PhoneBookEntry>()
        {
            new PhoneBookEntry() {PhoneNumber = "0851234", Name= "Ciaran", Address= "1 New Street"},
            new PhoneBookEntry() {PhoneNumber = "0851235", Name= "John", Address= "2 New Street"},
            new PhoneBookEntry() {PhoneNumber = "0851236", Name= "Mary", Address= "3 New Street"},
            new PhoneBookEntry() {PhoneNumber = "0851237", Name= "Jane", Address= "4 New Street"}

        };
        

        // GET: api/<PhoneBookAPI>
        [HttpGet]
        public IEnumerable<PhoneBookEntry> Get()
        {
            return _phonebook;
        }

        // GET api/<PhoneBookAPI>/123
        [HttpGet("ByName/{_name}")]
        
        public IEnumerable<PhoneBookEntry> GetByName(string _name)
        {
            return _phonebook.Where(p => p.Name.Equals(_name));
        }

        // GET api/<PhoneBookAPI>/999
        [HttpGet("ByNumber/{_number}")]
        public PhoneBookEntry GetByNumber(string _number)
        {

            return _phonebook.FirstOrDefault(p => p.PhoneNumber.Equals(_number));

        }

        // PUT api/<PhoneBookAPI>/5
        [HttpPut("{PhoneBookEntry}")]
        public ActionResult Put([FromBody] PhoneBookEntry value)
        {
            if (value == null)
            {
                return BadRequest("No Data in Request");
            }

            PhoneBookEntry p1 = _phonebook.FirstOrDefault(p => p.PhoneNumber.Equals(value.PhoneNumber));

            if (p1 != null)
            {
                return BadRequest("Record already exists");
            }

            _phonebook.Add(value);
            return Ok("Record Added");
        }

        
    }
}
