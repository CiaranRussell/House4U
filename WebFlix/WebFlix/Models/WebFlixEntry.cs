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


        //[Display(Name = "Release Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //public string ReleaseDate { get; set; }

        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Rating { get; set; }

    }
}
