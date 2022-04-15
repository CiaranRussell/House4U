// a movie

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebFlix.Data
{
    // various genres
    public enum Genre { Action, Adventure, Animation, Comedy, Crime, Drama, Fantasy, Family, Horror, SciFi, Thriller}

    // various certs
    public enum Certificate { Universal, Twelve, Fifteen, Eighteen}

    public class Movie
    {
        public int ID { get; set; }                         // unique

        [Required]
        public String Title { get; set; }         
                
        public List<Genre> Genres { get; set; }             // genres

        public Certificate Certificate { get; set; }

        public DateTime ReleaseDate { get; set; }           // year and month

        [Range(1, 10)]
        public double AverageRating { get; set; }

    }
}