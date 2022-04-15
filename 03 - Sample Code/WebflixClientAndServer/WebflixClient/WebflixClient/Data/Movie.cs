using System;
using System.Collections.Generic;
using System.Linq;

namespace WebFlix.Models
{
    // various genres
    public enum Genre { Action, Adventure, Animation, Comedy, Crime, Drama, Fantasy, Family, Horror, SciFi, Thriller }

    // various certs
    public enum Certificate { Universal, Twelve, Fifteen, Eighteen }

    public class Movie
    {
        public int ID { get; set; }                         // unique

        public String Title { get; set; }

        public List<Genre> Genres { get; set; }             // genres

        public Certificate Certificate { get; set; }

        public DateTime ReleaseDate { get; set; }           // year and month

        public double AverageRating { get; set; }

    
    public override string ToString()
        {
            String genres = "\n\tGenres: ";
            foreach (Genre g in Genres)
            {
                genres += Enum.GetName(typeof(Genre), g) + " ";
            }

            return "ID " + ID + " " + Title + " Cert: " + Certificate + " " +  " Year: " + ReleaseDate.Year + genres + "Average Rating " + AverageRating + "\n";
        }

    }

    // to hold anonymous type coming back from /movies/keyword/
    public class MovieWithIDandTitle
    {
        public int ID { get; set; }
        public String Title { get; set; }
    }
}