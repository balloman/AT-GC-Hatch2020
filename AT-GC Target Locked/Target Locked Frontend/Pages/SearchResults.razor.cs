using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AT_GC_Target_Locked.Io;
using AT_GC_Target_Locked.Models;
using AT_GC_Target_Locked.Models.PubTator;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Target_Locked_Frontend.Services;

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
            foreach (var check in Checks.Keys.ToList())
            {
                if (Checks[check])
                {
                    try
                    {
                        SearchData.SavedIds.Add(check, Array.Find(SearchData.PubTatorResults, data => 
                            data.Pmid.Equals(check, StringComparison.CurrentCultureIgnoreCase)));
                    }
                    catch (Exception e)
                    {
                        //TODO: Show the user a modal or something for trying to add more than once
                        Console.WriteLine(e);
                    }
                }
                Checks[check] = false;
            }
        }

        public void SetTags(SearchData.DisplayData data)
        {
            var parameters = new ModalParameters();
            parameters.Add("tags", data.Tags);
            var options = new ModalOptions()
            {
                Position = "blazored-modal-center"
            };
            Modal.Show<TagsComponent>("Tags", parameters);
        }
    }
}
