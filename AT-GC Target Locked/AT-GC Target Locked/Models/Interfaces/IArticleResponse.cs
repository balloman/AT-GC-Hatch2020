//Created by Bernard at 1:42 PM Saturday

using System.Collections.Generic;

namespace AT_GC_Target_Locked.Models.Interfaces
{
    /**
     * A preliminary interface for getting an article response
     */
    public interface IArticleResponse
    {
        public List<Tag> Tags { get; protected set; }
        public string Abstract { get; protected set; }
        
    }
}