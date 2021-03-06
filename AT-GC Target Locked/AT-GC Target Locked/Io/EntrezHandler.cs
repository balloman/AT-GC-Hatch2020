﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Io
{
    public class EntrezHandler
    {
        private HttpClient Client { get; }

        private const string BaseAddress =
            "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/"; 

        // ReSharper disable once InconsistentNaming
        private static readonly EntrezHandler INSTANCE = new EntrezHandler();
        
        public class NoResultsException : Exception
        {
            public NoResultsException()
            {
            }

            public NoResultsException(string message) : base(message)
            {
            }

            public NoResultsException(string message, Exception inner) : base(message, inner)
            {
            }

            protected NoResultsException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }
        }
        
        private EntrezHandler()
        {
            Client = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string[] Search(string term)
        {
            var pubList = GetPubList(term);
            var count = pubList["eSearchResult"]["Count"].ToObject<int>();
            if (count > 500)
            {
                Console.WriteLine("Query resulted in " + count + " terms. Maybe try a more specific query?");
            }else if (count == 0)
            {
                throw new NoResultsException();
            }
    
            return pubList["eSearchResult"]["IdList"]["Id"].ToObject<string[]>();
        }

        private JObject GetPubList(string term)
        {
            var response = Client.GetAsync("esearch.fcgi?term=" +
                                           HttpUtility.UrlEncode(term).ToLower() + "&sort=relevance").Result;
            var content = "";
            if (response.IsSuccessStatusCode)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new HttpRequestException("Http Request Failed :( " + response.StatusCode);
            }
            var doc = new XmlDocument();
            doc.LoadXml(content);
            var jsonContent = JsonConvert.SerializeXmlNode(doc);
            return JObject.Parse(jsonContent);
        }

        /**
         * Use this to grab the PubTatorHandler Instance
         */
        public static EntrezHandler GetInstance()
        {
            return INSTANCE;
        }
    }
}