using System;
using System.Collections.Generic;

namespace AT_GC_Target_Locked.Models.PubTator
{
    public class PubTatorResponse
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons;
        public List<Passage> Passages;
        public DateTime Created;
        public List<Tag> Tags;
        public string Journal;
        public int Year;
        public List<string> Authors;

        public class Passage
        {
            
        }
    }
}