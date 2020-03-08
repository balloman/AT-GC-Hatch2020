//Created by Bernard Allotey at 12:48 PM Saturday

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using AT_GC_Target_Locked.Models;
using AT_GC_Target_Locked.Models.PubTator;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Io
{
    /**
     * This class should be singleton, so only instantiated once, handles the WebIO
     */
    public class PubTatorHandler
    {
        private HttpClient Client { get; }

        private const string BaseAddress =
            "https://www.ncbi.nlm.nih.gov/research/pubtator-api/publications/export/biocjson"; 

        // ReSharper disable once InconsistentNaming
        private static readonly PubTatorHandler INSTANCE = new PubTatorHandler();

        
        private PubTatorHandler()
        {
            Client = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /**
         * Use this to grab the PubTatorHandler Instance
         */
        public static PubTatorHandler GetInstance()
        {
            return INSTANCE;
        }

        public PubTatorResponse GetArticleByPmId(string id)
        {
            var response = Client.GetAsync("?pmids=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return PubTatorResponse.ParseString(response.Content.ReadAsStringAsync().Result);
            }
            throw new HttpRequestException("This request failed :( " + response.StatusCode);
        }

        /// <summary>
        /// This function returns the article results assuming you have more than one variable
        /// </summary>
        /// <param name="id">A list of ids in any form that can be looped over</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public PubTatorResponse[] GetArticleByPmId(IEnumerable<string> id)
        {
            var requestUri = "?pmids=";
            var i = false;
            foreach (var s in id) //Simple loop to add every id to the end
            {
                if (!i)
                {
                    i = true;
                    requestUri += s;
                    continue;
                }
                requestUri += "," + s;
            } 
            var response = Client.GetAsync(requestUri).Result;
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("This request failed :( " + response.StatusCode);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var pubArray = new List<PubTatorResponse>();
            var iter = 0;
            foreach (var s in contentString.Split("\n"))
            {
                if (iter == contentString.Split("\n").Length-1)
                {
                    break;
                }

                try
                {
                    pubArray.Add(PubTatorResponse.ParseString(s));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                iter++;
            }

            return pubArray.ToArray();
        }
    }
}