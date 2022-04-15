using Microsoft.AspNetCore.Mvc;
using SMSService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMSService.Controllers
{
    [Route("api/SMSService")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        
        static List<SMSServiceEntry> SMSEntries = new List<SMSServiceEntry>();

        private readonly ILogger<SMSController> _logger;

        public SMSController(ILogger<SMSController> logger)
        {
            _logger = logger;
        }


        // GET: api/<SMSController>
        [HttpGet]
        public IEnumerable<SMSServiceEntry> Get()
        {
            return SMSEntries;
        }

       
        // PUT api/<SMSController>/5
        [HttpPut("SMSMessage")]
        public ActionResult Put([FromBody] SMSServiceEntry value)
        {
            if( value == null)
            {
                return BadRequest("No Data in Request");
            }
            
            if(value.Message.Length > 140)
            {
                return BadRequest("Message must not contain more than 140 character's");
            }

            SMSEntries.Add(value);
            return Ok("Message sent");
        }

        
    }
}
