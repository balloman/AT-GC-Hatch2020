﻿//Created by Bernard Allotey at 12:48 PM Saturday

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using AT_GC_Target_Locked.Models.Interfaces;

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

        public IArticleResponse GetArticleByPmId(string id)
        {
            var response = Client.GetAsync("?pmids=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            return null;
        }
    }
}