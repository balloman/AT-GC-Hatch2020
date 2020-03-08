//Created by Bernard Allotey at 11:40 AM Saturday

using System;
using System.Collections.Generic;
using System.Linq;
using AT_GC_Target_Locked.Io;

namespace AT_GC_Target_Locked
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Enter Search Terms: ");
            // string[] entries;
            // var term = Console.ReadLine();
            // try
            // {
            //     entries = EntrezHandler.GetInstance().Search(term);
            // }
            // catch (EntrezHandler.NoResultsException)
            // {
            //     Console.WriteLine("Could not find anything :(");
            //     return;
            // }
            // Console.WriteLine("Found " + entries.Length + " relevant articles!");
            // var termArray = term?.Split(" ").Where(
            //     s => !string.IsNullOrWhiteSpace(s)).ToList();
            // var i = 0;
            // foreach (var response in PubTatorHandler.GetInstance().GetArticleByPmId(entries))
            // {
            //     Console.WriteLine("Database: PubMed");
            //     Console.WriteLine("Article {0}: \tConfidence: {1}", i+1, 
            //         response.ComputeRelevance(termArray?.ToArray()));
            //     Console.WriteLine(response.Passages[0].Text);
            //     Console.WriteLine("TAGS: ");
            //     var duplicates = new List<string>();
            //     foreach (var annotation in from passage in response.Passages where passage.Annotations.Count > 0 
            //         from annotation in passage.Annotations where !duplicates.Contains(annotation.Text) 
            //         select annotation)
            //     {
            //         Console.WriteLine("{0}:\t{1}\t{2}", annotation.Infons["type"], 
            //             annotation.Infons["identifier"],
            //             annotation.Text);
            //         duplicates.Add(annotation.Text);
            //     }
            //     
            //     ResetScreen();
            //     i++;
            // }
            //
            // PubTatorHandler.GetInstance().GetArticleByPmId(entries);
            // Console.WriteLine();
            CitationHandler handler = new CitationHandler();
            handler.GetCitations(new []{ "25330715", "29659364" });
        }

        private static void ResetScreen()
        {
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }


    }
}