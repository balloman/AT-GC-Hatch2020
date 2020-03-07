//Created by Bernard at 1:42 PM Saturday

using System.Collections.Generic;
using AT_GC_Target_Locked.Models.PubTator;

namespace AT_GC_Target_Locked.Models.Interfaces
{
    /**
     * This interface is a base class for any annotation
     */
    public interface IAnnotation
    {
        public string Id { get; protected set; }
        public Infon Infons { get; protected set; }
        public string Text { get; protected set; }
        public List<Location> Locations { get; protected set; }
    }

    public struct Location
    {
        public int Offset;
        public int Length;
    }
}