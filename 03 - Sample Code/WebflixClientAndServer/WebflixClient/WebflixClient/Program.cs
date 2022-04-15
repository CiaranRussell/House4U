// console client for WebFlix API - 3 GETs

using System.Net.Http.Headers;

using WebFlix.Models;

namespace WebFlixClient
{

    class Client
    {
        // kick off
        static void Main()
        {
            //PatchAsync().Wait();
            GetsAsync().Wait();
            Console.ReadLine();
        }



        static async Task GetsAsync()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5221/api/webflix/");

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml

                    // GET ../carparks/all
                    // get all carparks
                    HttpResponseMessage response = await client.GetAsync("movies/all");              // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var movies = await response.Content.ReadAsAsync<IEnumerable<Movie>>();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // get movie IDs and titles for specified keyword
                    // GET ../movies/title/Strange
                    response = await client.GetAsync("movies/title/Strange");
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var movies = await response.Content.ReadAsAsync<IEnumerable<MovieWithIDandTitle>>();
                        foreach (var m in movies)
                        {
                            Console.WriteLine(m.ID + " " + m.Title);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // GET ../movies/id/1
                    // get movie with ID 1
                    response = await client.GetAsync("movies/id/3");
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var movie = await response.Content.ReadAsAsync<Movie>();
                        Console.WriteLine(movie);

                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
