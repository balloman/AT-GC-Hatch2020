using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target_Locked_Frontend.Pages;

namespace Target_Locked_Frontend.Services
{
    public class SearchData
    {
        public string Query { get; set; }
        public string[] Results { get; set; }

        public DisplayData[] PubTatorResults { get; set; }

        public List<string> SavedIds { get; set; }

        public SearchData()
        {
            SavedIds = new List<string>();
        }

        public struct DisplayData
        {
            public string Database { get; set; }
            public double Confidence { get; set; }
            public string Title { get; set; }
            public string Pmid { get; set; }
        }
    }
}
