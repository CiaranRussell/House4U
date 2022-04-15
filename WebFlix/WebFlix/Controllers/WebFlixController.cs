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
            new WebFlixEntry() {MovieId = 1, Title = "Fast and Furious", Certification = Certification.over15s, Genres = Genres.action, ReleaseDate = new DateTime(2006,01,01), Rating = 6},
            new WebFlixEntry() {MovieId = 2, Title = "Fast and Furious 6", Certification = Certification.over15s, Genres = Genres.action, ReleaseDate = new DateTime(2007,01,01), Rating = 6},
            new WebFlixEntry() {MovieId = 3, Title = "Brave Hart", Certification = Certification.over18s, Genres = Genres.drama, ReleaseDate = new DateTime(2008,01,01), Rating = 10},
            new WebFlixEntry() {MovieId = 4, Title = "Toy Story", Certification = Certification.universal, Genres = Genres.animation, ReleaseDate = new DateTime(2009,01,01), Rating = 7},
            new WebFlixEntry() {MovieId = 5, Title = "Pretty Women", Certification = Certification.over12s, Genres = Genres.family, ReleaseDate = new DateTime(2010,01,01), Rating = 4}
        };

        // GET: api/<WebFlixController>
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(entries.OrderBy(m => m.ReleaseDate).ToList());     
        }

        // GET api/<WebFlixController>/5
        [HttpGet("ByID/{id}")]
        public IActionResult GetbyID(int _ID)
        {
            try
            {
                var movie = entries.Where(p => p.MovieId.Equals(_ID));
                if (movie != null)
                {
                    return Ok(movie);
                }
                else
                {
                    return BadRequest("ID not found");
                }

            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet("entries/Title/{Title}")]
        public IActionResult GetbyTitleContains(string _title)
        {
            var results =  entries.FindAll(p => p.Title.ToLower().Contains(_title.ToLower()))
            .Select(WebFlixEntry => new { WebFlixEntry.MovieId, WebFlixEntry.Title });
            if (results.Count() == 0)
            {
                return NotFound();
            }
                return Ok(results);

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
