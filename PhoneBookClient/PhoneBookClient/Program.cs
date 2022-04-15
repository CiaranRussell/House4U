using PhoneBookAPI.Models;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace PhoneBookClient
{
    public class Program
    {
        static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5204/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PhoneBookEntry p1 = new PhoneBookEntry() {PhoneNumber = "089145697", Name = "Large", Address = "60 New Street"};
            AddPhoneBookEntry(client, p1).Wait();

            ListAllPhoneBookEntries(client).Wait();

        }

        private static async Task AddPhoneBookEntry(HttpClient client, PhoneBookEntry p1)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/PhoneBookAPI/aaa", p1);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record Added");
            }
        }

        static async Task ListAllPhoneBookEntries(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/PhoneBookAPI/");
            if (response.IsSuccessStatusCode)
            {
                var pbentries = await response.Content.ReadFromJsonAsync<IEnumerable<PhoneBookEntry>>();

                foreach (var entry in pbentries)
                {
                    Console.WriteLine(entry);
                }
            }
        }
    }
}
