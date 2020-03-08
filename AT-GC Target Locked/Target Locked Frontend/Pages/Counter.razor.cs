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
        private SearchQueryModel _searchQueryModel = new SearchQueryModel();

        void IncrementCount()
        {
            _currentCount++;
        }
    }
}
