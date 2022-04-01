using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using House4U.Data;



public class Programme
{

    static void Main()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5136/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HouseEntries he1 = new HouseEntries() { ID = "PR004", Address = "5 New Street", Email = "FR@gamil.com", leaseExpiry = new DateTime(2023, 12, 1), Lease = Lease.Delegated, NumBedrooms = 7 };
        ListAllHouseEntries(client).Wait();
        AddProperty(client, he1).Wait();
        UpdateProperty(client, he1).Wait();
        ListAllPropertyID(client).Wait();
        ListAllEmailAddress(client).Wait();

     
    }

    private static async Task ListAllHouseEntries(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("api/House4U/");
            if (response.IsSuccessStatusCode)
            {
                var house = await response.Content.ReadFromJsonAsync<IEnumerable<HouseEntries>>();

                Console.WriteLine("List All Property Entires");

                foreach (var entries in house)
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

    private static async Task AddProperty(HttpClient client, HouseEntries payload)
    {
        try
        {

            HttpResponseMessage response = await client.PostAsJsonAsync("api/House4U/", payload);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record Added");
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

    private static async Task UpdateProperty(HttpClient client, HouseEntries payload)
    {

        payload.NumBedrooms = 9;
        HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("api/House4U/{0}", payload.ID), payload);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Bendrooms updated");
        }
        else
        {
            Console.WriteLine(response.StatusCode.ToString());
        }

    }

    private static async Task ListAllPropertyID(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("api/House4U/ByID/PR001?_ID=PR001");
            if (response.IsSuccessStatusCode)
            {
                var property = await response.Content.ReadFromJsonAsync<IEnumerable<HouseEntries>>();


                foreach (var entries in property)
                {
                    Console.WriteLine("");
                    Console.WriteLine("List Property by ID");
                    Console.WriteLine(entries);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    static async Task ListAllEmailAddress(HttpClient client)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("Email/%40?_email=%40");
            if (response.IsSuccessStatusCode)
            {
                var house = await response.Content.ReadFromJsonAsync<IEnumerable<HouseEntries>>();

                Console.WriteLine("");
                Console.WriteLine("List all Email address by @ ");

                foreach (var entries in house)
                {

                    Console.WriteLine("Email: " + entries.Email);

                }

                Console.WriteLine("");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


}


