using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked.Models
{
    public class Annotation 
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public string Text { get; set; }
        public List<Location> Locations { get; set; }
        public static Annotation ParseString(string json)
        {
            Annotation thisAnnotation = new Annotation();
            JObject jsonAnnotation = JObject.Parse(json);
            thisAnnotation.Id = jsonAnnotation.GetValue("id").ToObject<String>();
            thisAnnotation.Infons = jsonAnnotation.GetValue("infons").ToObject<Dictionary<string,string>>();
            var locationsArray = jsonAnnotation.GetValue("locations").ToObject<Location[]>();
            thisAnnotation.Locations = locationsArray.OfType<Location>().ToList();
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
