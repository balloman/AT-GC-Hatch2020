using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target_Locked_Frontend.Models;

namespace Target_Locked_Frontend.Pages
{
    public partial class Counter
    {
        private int _currentCount = 0;
        private SearchModel _searchModel = new SearchModel();

        void IncrementCount()
        {
            string[] data = AT_GC_Target_Locked.Io.EntrezHandler.GetInstance().Search(_searchModel.Query);
            SearchData.Query = data;
            NavigationManager.NavigateTo("SearchResults");
        }
    }
}
