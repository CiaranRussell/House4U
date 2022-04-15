using SMSService.Models;
using System.Net.Http.Headers;
using System;
using System.Net.Http.Json;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

namespace SMSServiceClient
{
    public class Programme
    {
        static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5019/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            FileLogger logger = new FileLogger();
            SMSServiceEntry entry = new SMSServiceEntry(logger, "085123456", "087145623", "Hello World");
            AddSMS(client, entry).Wait();

            entry.LogSMSMessage();
            ListSMS(client).Wait();

        }

        
        private static async Task AddSMS(HttpClient client, SMSServiceEntry entry)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/SMSService/SMSMessage/", entry);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Record Added");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static async Task ListSMS(HttpClient client)
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/SMSService/");
                if (response.IsSuccessStatusCode)
                {
                    var smsentries = await response.Content.ReadFromJsonAsync<IEnumerable<SMSServiceEntry>>();

                    foreach (var entries in smsentries)
                    {
                        Console.WriteLine(entries);

                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }


    }

}


