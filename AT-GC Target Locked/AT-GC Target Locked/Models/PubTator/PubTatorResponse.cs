using System;
using System.Collections.Generic;

namespace AT_GC_Target_Locked.Models.PubTator
{
    public class PubTatorResponse
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public List<Passage> Passages { get; set; }
        public DateTime Created { get; set; }
        public List<Tag> Tags { get; set; }
        public string Journal { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public class Passage
        {
            public Dictionary<string, string> Infons { get; set; }
            public int Offset { get; set; }
            public string Text { get; set; }
            public List<string> Sentences { get; set; }
            public List<Annotation> Annotations { get; set; }
        }

        public static PubTatorResponse ParseString(string json)
        {
            var response = new PubTatorResponse();
            //Some Code
            return response;
        }
    }
}