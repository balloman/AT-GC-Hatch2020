using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Target_Locked_Frontend.Pages
{
    public partial class SearchResults
    {
        public string[] Results { get; set; }

        protected override void OnInitialized()
        {
            Results = SearchData.Query;
        }
    }
}
