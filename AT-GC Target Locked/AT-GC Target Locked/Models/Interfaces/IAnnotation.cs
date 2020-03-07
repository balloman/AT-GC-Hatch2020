//Created by Bernard at 1:42 PM Saturday

using System.Collections.Generic;

namespace AT_GC_Target_Locked.Models.Interfaces
{
    /**
     * This interface is a base class for any annotation
     */
    public interface IAnnotation
    {
        public string Id { get; protected set; }
        public Dictionary<string, string> Infons { get; protected set; }
        public string Text { get; protected set; }
        public List<Location> Locations { get; protected set; }
    }

    public struct Location
    {
        public int Offset;
        public int Length;
    }
}