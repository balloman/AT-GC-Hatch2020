using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT_GC_Target_Locked.Io;
using Target_Locked_Frontend.Models;
using Target_Locked_Frontend.Services;

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
            SearchData.PubTatorResults = GetResponses(data);
            NavigationManager.NavigateTo("SearchResults");
        }

        SearchData.DisplayData[] GetResponses(string[] ids)
        {
            Console.WriteLine("CheckAgain");
            var i = 0;
            var displayDatas = new List<SearchData.DisplayData>();
            foreach (var response in PubTatorHandler.GetInstance().GetArticleByPmId(ids))
            {
                var termArray = SearchData.Query?.Split(" ").Where(
                    s => !string.IsNullOrWhiteSpace(s)).ToList();
                var data = new SearchData.DisplayData
                {
                    Database = "PubMed",
                    Confidence = response.ComputeRelevance(termArray?.ToArray()),
                    Pmid = ids[i],
                    Title = response.Passages[0].Text
                };
                displayDatas.Add(data);
                // Console.WriteLine("TAGS: ");
                // var duplicates = new List<string>();
                // foreach (var annotation in from passage in response.Passages
                //     where passage.Annotations.Count > 0
                //     from annotation in passage.Annotations
                //     where !duplicates.Contains(annotation.Text)
                //     select annotation)
                // {
                //     Console.WriteLine("{0}:\t{1}\t{2}", annotation.Infons["type"],
                //         annotation.Infons["identifier"],
                //         annotation.Text);
                //     duplicates.Add(annotation.Text);
                // }

                i++;
            }

            return displayDatas.ToArray();
        }
    }
}
