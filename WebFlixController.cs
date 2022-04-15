using Microsoft.AspNetCore.Mvc;
using WebFlix.Models;
using System.Data;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebFlixController : ControllerBase
    {
        
        static List<WebFlixEntry> entries = new List<WebFlixEntry>()
        {
            new WebFlixEntry() {MovieId = 1, Title = "Fast and Furious", Certification = Certification.over15s, Genres = Genres.action, Releasedate = "31/12/2010", Rating = 6},
            new WebFlixEntry() {MovieId = 2, Title = "Fast and Furious 6", Certification = Certification.over15s, Genres = Genres.action, Releasedate = "31/12/2018", Rating = 6},
            new WebFlixEntry() {MovieId = 3, Title = "Brave Hart", Certification = Certification.over18s, Genres = Genres.drama, Releasedate = "31/12/2015", Rating = 10},
            new WebFlixEntry() {MovieId = 4, Title = "Toy Story", Certification = Certification.universal, Genres = Genres.animation, Releasedate = "31/12/2016", Rating = 7},
            new WebFlixEntry() {MovieId = 5, Title = "Pretty Women", Certification = Certification.over12s, Genres = Genres.family, Releasedate = "01/07/2004", Rating = 4}
        };

        // GET: api/<WebFlixController>
        [HttpGet]
        public IEnumerable<WebFlixEntry> Get()
        {
            
            return entries;     
        }

        // GET api/<WebFlixController>/5
        [HttpGet("ByID/{id}")]
        public IEnumerable<WebFlixEntry>  GetbyID(int _ID)
        {
            return entries.Where(p => p.MovieId.Equals(_ID));
        }

        [HttpGet("ByTitle/{Title}")]
        public IEnumerable<WebFlixEntry> GetbyTitleContains(string _title)
        {
            return (IEnumerable<WebFlixEntry>)entries.FindAll(p => p.Title.ToLower().Contains(_title.ToLower()));
            // .Select(WebFlixEntry => new { WebFlixEntry.MovieId, WebFlixEntry.Title })

            
        }

        //POST api/<WebFlixController>
        [HttpPost]
        public ActionResult PostWebFlixEntry([FromBody] WebFlixEntry webFlixEntry)
        {
            if (webFlixEntry == null)
            {
                return BadRequest("No Data in Request");
            }
            WebFlixEntry wf1 = entries.FirstOrDefault(p => p.MovieId.Equals(webFlixEntry.MovieId));
            
            if (wf1 != null)
            {
                return BadRequest("Record Aleady Exists");
            }
            entries.Add(webFlixEntry);
            return Ok("Record Added");
        }

        // PUT api/<WebFlixController>/5
        [HttpPut("{id}")]
        public IActionResult PutWebFlixEntryUpdate(int id, WebFlixEntry webFlixEntry)
        {
            if (id != webFlixEntry.MovieId)
            {
                return BadRequest("Movie ID not found");
            }
            WebFlixEntry wf1 = entries.FirstOrDefault(p => p.MovieId.Equals(webFlixEntry.MovieId));

            if (wf1 != null)
            {
                wf1.Title = webFlixEntry.Title;
                return Ok("Record Updated");
            }
            return BadRequest("Movie ID not found");

        }

        // DELETE api/<WebFlixController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWebFlixEntry(int id)
        {
            var delete = entries.SingleOrDefault(p => p.MovieId == id);
            if (delete != null)
            {
                entries.Remove(delete);
                return Ok("Movie Removed");
            }
            return BadRequest("Movie ID not found");
            
        }

        
    }
}
