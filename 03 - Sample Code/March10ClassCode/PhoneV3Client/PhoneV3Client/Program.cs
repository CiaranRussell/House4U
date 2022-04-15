using PhoneBook.Models;

namespace PhoneBook
{
    public class PhoneV3Client
    {
        public static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5249/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            PhoneBookEntry entry = new PhoneBookEntry() {PhoneNumber="089-1235676", Name="Molly Malone", Address="Chancellors Road" };
            AsyncAddAPhoneBookEntry(client, entry).Wait();
            AsyncUpdateAPhoneBookEntry(client, entry).Wait();
            AsyncDeleteAPhoneBookEntry(client, entry.PhoneNumber).Wait();

        }

        private static async Task AsyncAddAPhoneBookEntry(HttpClient client, PhoneBookEntry payload)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/PhoneBook", payload);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record added!");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
        }

        private static async Task AsyncUpdateAPhoneBookEntry(HttpClient client, PhoneBookEntry payload)
        {
            payload.Name = "Updated Name";
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("api/PhoneBook/{0}", payload.PhoneNumber), payload);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record added!");
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
        }

        private static async Task AsyncDeleteAPhoneBookEntry(HttpClient client, string phoneNumber)
        {
            
            HttpResponseMessage response = await client.DeleteAsync(string.Format("api/PhoneBook/{0}", phoneNumber));
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
}