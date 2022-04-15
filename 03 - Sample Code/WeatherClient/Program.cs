namespace weather
{
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    

    public class Program
    {
        static void Main()
        {
            DoRestStuff().Wait();
        }

        private static async Task DoRestStuff()
        {
            HttpClient myClient = new HttpClient();
            myClient.BaseAddress = new Uri("http://localhost:5169/WeatherForecast/");
            myClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = await myClient.GetAsync("Forecast");
            if (response.IsSuccessStatusCode)
            {
                var forecasts = await response.Content.ReadAsAsync<IEnumerable<object>>();
                foreach (var forecast in forecasts)
                {
                    Console.WriteLine(forecast);
                }
            }

        }
    }
}
