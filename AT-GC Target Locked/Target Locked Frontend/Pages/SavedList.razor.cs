using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal;
using Target_Locked_Frontend.Services;

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
    }
}
