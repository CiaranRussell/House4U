using SMSGateway.Models;

namespace SMSClient
{
    public class SMSClient
    {
        static void Main()
        {
            DoTheRESTCalls().Wait();
        }

        private static async Task DoTheRESTCalls()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5092/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            TextMessage txt = new TextMessage() { FromNumber = "555888", Content = "Think they're gonna win?", ToNumber = "0862221211" };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/SMSGateway", txt);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message has been sent");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
        }
    }
}