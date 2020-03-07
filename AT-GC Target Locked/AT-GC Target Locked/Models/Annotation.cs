using System;
using System.Collections.Generic;
using System.Text;
using AT_GC_Target_Locked.Models.Interfaces;

namespace AT_GC_Target_Locked.Models
{
    class Annotation: IAnnotation 
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public string Text { get; set; }
        public List<Location> Locations { get; set; }
        //holds the json to parse
        public IAnnotation ParseString(string json)
        {
            this.Text = json;
            return this;
        }

    }
}
