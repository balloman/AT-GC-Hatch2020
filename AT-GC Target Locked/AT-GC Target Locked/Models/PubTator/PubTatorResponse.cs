using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Models.PubTator
{
    public class PubTatorResponse
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public List<Passage> Passages { get; set; }
        public DateTime Created { get; set; }
        public List<Accessor> Tags { get; set; }
        public string Journal { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public PubTatorResponse()
        {
            Infons = new Dictionary<string, string>();
            Passages = new List<Passage>();
            Tags = new List<Accessor>();
            Authors = new List<string>();
        }

        public class Passage
        {
            public Dictionary<string, string> Infons { get; set; }
            public int Offset { get; set; }
            public string Text { get; set; }
            public List<string> Sentences { get; set; }
            public List<Annotation> Annotations { get; set; }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public struct Accessor
        {
            public Tag tag;
            public String data;
        }

        public static PubTatorResponse ParseString(string json)
        {
            JObject jsonAnnotation = JObject.Parse(json);
            var response = new PubTatorResponse();
            response.Id = jsonAnnotation.GetValue("id").ToObject<String>();
            response.Infons = jsonAnnotation.GetValue("infons").ToObject<Dictionary<string,string>>();
            var passagesArray = JArray.Parse(jsonAnnotation["passages"].ToString());
            foreach (var passage in passagesArray)
            {
                var passageObject = new Passage();
                passageObject.Infons = passage["infons"].ToObject<Dictionary<String, String>>();
                passageObject.Offset = passage["offset"].ToObject<int>();
                passageObject.Text = passage["text"].ToObject<String>();
                var annotationsListString = passage["annotations"].ToString();
                var annotationsListArray = JArray.Parse(annotationsListString);
                passageObject.Annotations = new List<Annotation>();
                foreach (var token in annotationsListArray)
                {
                    passageObject.Annotations.Add(Annotation.ParseString(token.ToString()));
                }
                response.Passages.Add(passageObject);
            }

            var date = jsonAnnotation.GetValue("created");
            response.Created = DateTimeOffset.FromUnixTimeMilliseconds(jsonAnnotation.GetValue("created")["$date"].ToObject<long>()).DateTime;
            var tagsArray = JArray.Parse(jsonAnnotation["accessions"].ToString());
            foreach (var token in tagsArray)
            {
                var accessionString = token.ToString();
                var parts = accessionString.Split("@");
                Tag myTag;
                Enum.TryParse(parts[0], out myTag);
                response.Tags.Add(new Accessor
                {
                    tag = myTag, data = parts[1]
                });
            }
            var authorsArray = jsonAnnotation.GetValue("authors").ToObject<List<String>>();
            response.Authors = authorsArray;
            response.Journal = jsonAnnotation.GetValue("journal").ToObject<String>();
            response.Year = jsonAnnotation.GetValue("year").ToObject<int>();
            return response;
        }
    }
}