using House4UAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HouseMgt
{
    class Program
    {
        private static HttpClient theAPI;

        private static void Main(string[] args)
        {
            theAPI = new HttpClient();
            theAPI.BaseAddress = new Uri("http://localhost:63725/");
            theAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddAClient().Wait();
            AddAProp().Wait();
            UpdateProp().Wait();
            GetClientinNameOrder().Wait();
            GetClientinIDOrder().Wait();
            GetAllProperties().Wait();
            GetPropertiesByClientID().Wait();
            GetPropertiesByClientName().Wait();
        }

        //Op1 - add a client
        private static async Task AddAClient()
        {
            Client c1 = new Client() { ID = 2, Name = "John D", Phone = "555-333", EmailAddress = "stuff@nonsense" };
            HttpResponseMessage response = await theAPI.PostAsJsonAsync("api/AddClient", c1);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Client Added");
            }
            else
            {
                Console.WriteLine("AddClient - " + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op2 - add a property
        private static async Task AddAProp()
        {
            Property p1 = new Property() { ID = 2, Address = "1 Wattle Crescent", BedroomCount = 3, FullyDelegated = false, ClientID = 0, LeaseExpiry = new DateTime(2020, 1, 1) };
            HttpResponseMessage response = await theAPI.PostAsJsonAsync("api/AddProp", p1);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Property Added");
            }
            else
            {
                Console.WriteLine("AddProp -"+response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op3 - Update bedroom count
        private static async Task UpdateProp()
        {
            Property p1 = new Property() { ID = 2, Address = "", BedroomCount = 5, FullyDelegated = false, ClientID = 0, LeaseExpiry = new DateTime(2020, 1, 1) };
            HttpResponseMessage response = await theAPI.PutAsJsonAsync("api/Update/0", p1);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Property updated");
            }
            else
            {
                Console.WriteLine("Update - " + response.StatusCode + " " + response.ReasonPhrase);
            }
        }
        
        //Op4 - All clients sorted by name
        private static async Task GetClientinNameOrder()
        {
            HttpResponseMessage response = await theAPI.GetAsync("api/AllClientsByName");
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var clients = await response.Content.ReadAsAsync<IEnumerable<Client>>();
                foreach (var c in clients)
                {
                    Console.WriteLine("Client: " + c.Name);
                }
            }
            else
            {
                Console.WriteLine("AllClientsByName - "+response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op5 - All clients sorted by id
        private static async Task GetClientinIDOrder()
        {
            HttpResponseMessage response = await theAPI.GetAsync("api/AllClientsByID");
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var clients = await response.Content.ReadAsAsync<IEnumerable<Client>>();
                foreach (var c in clients)
                {
                    Console.WriteLine("Client: "+c.ID);
                }
            }
            else
            {
                Console.WriteLine("AllClientsByID - "+ response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op6 - All properties
        private static async Task GetAllProperties()
        {
            HttpResponseMessage response = await theAPI.GetAsync("api/AllProps");
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var props = await response.Content.ReadAsAsync<IEnumerable<Property>>();
                foreach (var p in props)
                {
                    Console.WriteLine("Property: " + p.Address);
                }
            }
            else
            {
                Console.WriteLine("AllProps - "+response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op7 - Properties by Client ID
        private static async Task GetPropertiesByClientID()
        {
            HttpResponseMessage response = await theAPI.GetAsync("api/AllPropsForClientID/0");
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var props = await response.Content.ReadAsAsync<IEnumerable<Property>>();
                foreach (var p in props)
                {
                    Console.WriteLine("Client 0 : " + p.Address);
                }
            }
            else
            {
                Console.WriteLine("aAllPropsForClientID - " + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        //Op7 - Properties by Client ID
        private static async Task GetPropertiesByClientName()
        {
            HttpResponseMessage response = await theAPI.GetAsync("api/AllPropsForClientName/Landlord Jim");
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var props = await response.Content.ReadAsAsync<IEnumerable<Property>>();
                foreach (var p in props)
                {
                    Console.WriteLine("Client Landlord Jim : " + p.Address);
                }
            }
            else
            {
                Console.WriteLine("aAllPropsForClientName - " + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

    }
}






