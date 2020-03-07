//Created by Bernard at 1:42 PM Saturday

using System.Collections.Generic;

namespace AT_GC_Target_Locked.Models.Interfaces
{
    /**
     * This interface is a base class for any annotation
     */
    public interface IAnnotation
    {
        public string Id { get; set; }
        public Dictionary<string, string> Infons { get; set; }
        public string Text { get; set; }
        public List<Location> Locations { get; set; }
        public IAnnotation ParseString(string json);
    }

    public struct Location
    {
        public int Offset;
        public int Length;
    }
}