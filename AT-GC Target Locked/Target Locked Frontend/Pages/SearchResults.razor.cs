using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT_GC_Target_Locked.Io;
using AT_GC_Target_Locked.Models.PubTator;
using Microsoft.AspNetCore.Components;

namespace Target_Locked_Frontend.Pages
{
    public partial class SearchResults
    {
        public string[] Results { get; set; }
        public Dictionary<string, bool> Checks { get; set; }

        protected override void OnInitialized()
        {
            Results = SearchData.Results;
            Checks = new Dictionary<string, bool>();
            foreach (var data in SearchData.PubTatorResults)
            {
                Checks.Add(data.Pmid, false);
            }
        }

        public void ButtonClicked()
        {
            var i = 0;
            foreach (var check in Checks.Keys.ToList())
            {
                if (Checks[check])
                {
                    SearchData.SavedIds.Add(check);
                }
                Checks[check] = false;
            }
        }
    }
}
