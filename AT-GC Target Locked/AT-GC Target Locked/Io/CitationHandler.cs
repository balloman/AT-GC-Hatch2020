using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Io
{
    public class CitationHandler
    {
        HttpClient httpClient = new HttpClient();

        public string[] GetCitations(string[] pubIds)
        {
            List<String> citations = new List<string>();
            httpClient.BaseAddress = new Uri("https://api.ncbi.nlm.nih.gov/lit/ctxp/v1/pubmed/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HATCH2020 Genomics Competition");
            foreach (var pubId in pubIds)
            {
                var result = httpClient.GetAsync($"?format=citation&contenttype=json&id={pubId}").Result;
                if (!result.IsSuccessStatusCode)
                {
                    continue;
                }
                citations.Add(JObject.Parse(result.Content.ReadAsStringAsync().Result)["apa"]["format"].ToString());
            }
            return citations.ToArray();
        }
    }
}
