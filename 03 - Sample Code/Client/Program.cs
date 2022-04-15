using PhoneBook.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;

namespace PhoneBookClient
{
    public class Program
    {
        static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5277/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ListAllPhoneBookEntries(client).Wait();

            PhoneBookEntry p1 = new PhoneBookEntry() { PhoneNumber = "123456789", Name = "Patrick Hoban", Address = "Galway" };
            AddPhoneBookEntry(client, p1).Wait();
        }

        private static async Task AddPhoneBookEntry(HttpClient client, PhoneBookEntry p1)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("api/PhoneBook/ddd", p1);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record Added");
            }
        }

        static async Task ListAllPhoneBookEntries(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/PhoneBook");
            if (response.IsSuccessStatusCode)
            {
                var pbEntries = await response.Content.ReadAsAsync<IEnumerable<PhoneBookEntry>>();

                foreach (var entry in pbEntries)
                {
                    Console.WriteLine(entry);
                }

            }
        }
    }

}