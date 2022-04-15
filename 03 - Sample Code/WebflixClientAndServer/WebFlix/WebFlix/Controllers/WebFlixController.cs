using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebFlix.Data;

namespace WebFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebFlixController : ControllerBase
    {
        // populate movies and and reviews..
        static private List<Movie> movies = new List<Movie>
        {
            new Movie()
            {
                ID = 1,
                Title = "Doctor Strange",
                Genres = new List<Genre> { Genre.Action, Genre.Adventure, Genre.Fantasy },
                Certificate = Certificate.Twelve,
                ReleaseDate = new DateTime(2016, 9, 1),
                AverageRating = 5
            },
            new Movie()
            {
                ID = 2,
                Title = "Allied",
                Genres = new List<Genre> { Genre.Action, Genre.Adventure, Genre.Drama },
                Certificate = Certificate.Fifteen,
                ReleaseDate = new DateTime(2016, 11, 1),
                AverageRating = 6
            },
            new Movie()
            {
                ID = 3,
                Title = "Nocturnal Animals",
                Genres = new List<Genre> { Genre.Drama, Genre.Thriller},
                Certificate = Certificate.Fifteen,
                ReleaseDate = new DateTime(2016, 10, 1),                        // no review yet
                AverageRating = 8
            }
        };


        // return all movies in reverse release date order
        [HttpGet("movies/all")]
        //[Route("movies/all")]
        public IActionResult GetAllMovies()
        {
            return Ok(movies.OrderByDescending(m => m.ReleaseDate).ToList());
        }

        // return ID and title for movies matching 'keyword' as a whole word in title
        [HttpGet("movies/title/{keyword}")]
        //[Route("movies/title/{keyword}")]
        public IActionResult GetAllMoviesByTitleKeyword(String keyword)
        {
            // return ID and title for matches whole word only
            String pattern = @"\b" + keyword.ToUpper() + @"\b";         // \bKEYWORD\b
            var results = movies.Where(m => Regex.Match(m.Title.ToUpper(), pattern).Success == true).Select(m => new { m.ID, m.Title });
            if (results.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(results);
            }

        }

        // get movie by ID
        [HttpGet("movies/id/{id:int}")]
        //[Route("movies/id/{id:int}")]
        public IActionResult GetMovieByID(int id)
        {
            try
            {
                var movie = movies.SingleOrDefault(m => m.ID == id);
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
    }
}
