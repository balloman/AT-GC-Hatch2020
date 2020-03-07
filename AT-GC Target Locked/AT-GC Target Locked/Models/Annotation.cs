using System;
using System.Collections.Generic;
using System.Text;
using AT_GC_Target_Locked.Models.Interfaces;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Models
{
    public class Annotation 
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public string Text { get; set; }
        public List<Location> Locations { get; set; }
        //holds the json to parse
        public static Annotation ParseString(string json)
        {
            Annotation thisAnnotation = new Annotation();
            JObject jsonAnnotation = JObject.Parse(json);
            thisAnnotation.Text = json;
            return thisAnnotation;
        }


        public struct Location
        {
            public int Offset;
            public int Length;
        }
    }
}
