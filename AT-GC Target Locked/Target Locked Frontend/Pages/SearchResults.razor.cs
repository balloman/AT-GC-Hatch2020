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

        protected override void OnInitialized()
        {
            Results = SearchData.Results;
        }

        DisplayData[] GetResponses(string[] ids)
        {
            var i = 0;
            var displayDatas = new List<DisplayData>();
            foreach (var response in PubTatorHandler.GetInstance().GetArticleByPmId(ids))
            {
                var termArray = SearchData.Query?.Split(" ").Where(
                    s => !string.IsNullOrWhiteSpace(s)).ToList();
                var data = new DisplayData
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

        public struct DisplayData
        {
            public string Database { get; set; }
            public double Confidence { get; set; }
            public string Title { get; set; }
            public string Pmid { get; set; }
        }
    }
}
