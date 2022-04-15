using Microsoft.AspNetCore.Mvc;
using SMSGateway.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMSGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSGatewayController : ControllerBase
    {
        private const string LOGFILENAME = @"c:\temp\messages.txt";
        private const int MaxSize = 140;

        // POST api/<SMSGateway>
        [HttpPost]
        public ActionResult Post([FromBody] TextMessage value)
        {
            if (ModelState.IsValid)
            {
                Log(String.Format("Sent: {0} from {1} to {2} at {3}", value.Content, value.FromNumber, value.ToNumber, DateTime.Now.ToShortTimeString()));
                return Ok();
            }
            else
            {
                return BadRequest("Invalid SMS format!");
            }
        }

        private void Log(string message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(LOGFILENAME, true);
                sw.Write(message);
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
