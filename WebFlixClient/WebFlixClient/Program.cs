using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using WebFlix.Models;
using static WebFlix.Models.WebFlixEntry;

public class Programme
{
    static void Main()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5240/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        WebFlixEntry WF1 = new WebFlixEntry() { MovieId = 8, Title = "New Movie", Genres = Genres.adventure, Certification = Certification.over18s, Releasedate = new DateTime(2012, 01, 01), Rating = 8 };

        ListAllWebFlixEntries(client).Wait();
        ListAllWebFlixEntriesByMovieID(client).Wait();
        ListAllWebFlixEntriesByTitleContains(client).Wait();
        AddWebflixEntry(client).Wait();
        AddWebflixEntry1(client, WF1).Wait();
        UpdateWebflixEntry(client, WF1).Wait();
        //DeleteWEbFlixEntry(client, WF1.MovieId).Wait();



    }

    private static async Task ListAllWebFlixEntries(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("api/WebFlix/");
            if (response.IsSuccessStatusCode)
            {
                var WFentries = await response.Content.ReadFromJsonAsync<IEnumerable<WebFlixEntry>>();

                Console.WriteLine("List All Movie Entires");

                foreach (var entries in WFentries)
                {
                    Console.WriteLine(entries);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    static async Task ListAllWebFlixEntriesByTitleContains(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("api/WebFlix/entries/Title/Fast?_title=Fast");
            if (response.IsSuccessStatusCode)
            {
                var WFentries = await response.Content.ReadFromJsonAsync<IEnumerable<WebFlixEntry>>();

                Console.WriteLine("");
                Console.WriteLine("List Movies by Title that Contain 'Fast' ");

                foreach (var entries in WFentries)
                {
                    
                    Console.WriteLine("Movie ID: " + entries.MovieId + " | Title: " + entries.Title);
                    
                }

                    Console.WriteLine("");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private static async Task ListAllWebFlixEntriesByMovieID(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("api/WebFlix/ByID/3?_ID=3");
            if (response.IsSuccessStatusCode)
            {
                var WFentries = await response.Content.ReadFromJsonAsync<IEnumerable<WebFlixEntry>>();
                

                foreach (var entries in WFentries)
                {
                    Console.WriteLine("");
                    Console.WriteLine("List Movies by movie ID");
                    Console.WriteLine(entries);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    private static async Task AddWebflixEntry(HttpClient client)
    {   
        try
        {
            WebFlixEntry webFlixEntry = new WebFlixEntry() { MovieId = 7, Title = "New Movie", Genres = Genres.adventure, Certification = Certification.over18s, Releasedate = new DateTime(2011, 01, 01), Rating = 8 };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/WebFlix", webFlixEntry);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie Added");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
            
    }

    private static async Task AddWebflixEntry1(HttpClient client, WebFlixEntry payload)
    {
        try
        {
            
            HttpResponseMessage response = await client.PostAsJsonAsync("api/WebFlix", payload);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie Added");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    private static async Task UpdateWebflixEntry(HttpClient client, WebFlixEntry payload)
    {
       
        payload.Title = "New Movie 2";
        HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("api/WebFlix/{0}", payload.MovieId), payload);
        
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Movie Title updated");
        }
        else
        {
            Console.WriteLine(response.StatusCode.ToString());
        }

    }

    private static async Task DeleteWEbFlixEntry(HttpClient client, int movieID)
    {

        HttpResponseMessage response = await client.DeleteAsync(string.Format("api/WebFlix/8", movieID));
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Record deleted!");
        }
        else
        {
            Console.WriteLine(response.StatusCode.ToString());
        }
    }


}
