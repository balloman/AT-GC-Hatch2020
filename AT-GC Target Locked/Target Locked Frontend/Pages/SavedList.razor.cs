using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.Modal;
using Target_Locked_Frontend.Services;
using AT_GC_Target_Locked.Io;

namespace Target_Locked_Frontend.Pages
{
    public partial class SavedList
    {
        public string[] Results;
        public Dictionary<string, bool> Checks { get; set; }

        protected override void OnInitialized()
        {
            Results = SearchData.Results;
            Checks = new Dictionary<string, bool>();
            foreach (var data in SearchData.SavedIds)
            {
                Checks.Add(data.Key, false);
            }
        }

        public void ButtonClicked()
        {
            foreach (var check in Checks.Keys.ToList())
            {
                if (Checks[check])
                {
                    SearchData.SavedIds.Remove(check);
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

        public async void ExportClicked()
        {
            List<String> pubIds = new List<string>();
            foreach (var check in Checks.Keys.ToList())
            {
                if (Checks[check])
                {
                    pubIds.Add(check);
                }
                Checks[check] = false;
            }
            var citations = new CitationHandler().GetCitations(pubIds.ToArray());
            File.WriteAllLines("citations.txt", citations);
        }
    }
}
