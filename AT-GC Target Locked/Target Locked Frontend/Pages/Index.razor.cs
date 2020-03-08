using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target_Locked_Frontend.Models;

namespace Target_Locked_Frontend.Pages
{
    public partial class Index
    {
        private SearchQueryModel _searchQueryModel = new SearchQueryModel();

        void Search()
        {
            var data = AT_GC_Target_Locked.Io.EntrezHandler.GetInstance().Search(_searchQueryModel.Query);
            SearchData.Query = _searchQueryModel.Query;
            SearchData.Results = data;
            NavigationManager.NavigateTo("SearchResults");
        }
    }
}
