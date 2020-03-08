using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Io
{
    class stemswip
    {
        static void yeet(string[] args)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.dictionaryapi.com/api/v3/references/medical/json/");
                var result = client.GetAsync("doctor?key=7fb00dd9-69be-4a0a-a02b-b05190a39768").Result;

                var jsonString = result.Content.ReadAsStringAsync().Result;
                var webJson = JArray.Parse(jsonString);
                var first = webJson[0];
                JObject.Load(first.CreateReader());
                Console.ReadKey();


            }
    }
}
