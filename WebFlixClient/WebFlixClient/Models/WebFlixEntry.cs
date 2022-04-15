using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebFlix.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genres { action, adventure, animation, comedy, crime, drama, fantasy, family, horror, scifi, thriller };

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Certification { universal, over12s, over15s, over18s };


    public class WebFlixEntry
    {
        [Required(ErrorMessage = "Movie ID is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public Genres Genres { get; set; }

        public Certification Certification { get; set; }

        public DateTime Releasedate { get; set; }

        
        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Rating { get; set; }

        
        public override string ToString()
        {
            return String.Format("MovieID: {0} | Title: {1} | Genres: {2} | Certification: {3} | Release Date: {4} | Rating: {5}", MovieId, Title, Genres, Certification, Releasedate, Rating);
        }

        
    } 
}
