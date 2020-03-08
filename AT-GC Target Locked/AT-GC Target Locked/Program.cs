//Created by Bernard Allotey at 11:40 AM Saturday

using System;
using AT_GC_Target_Locked.Io;
using AT_GC_Target_Locked.Models;
using Newtonsoft.Json.Linq;

namespace AT_GC_Target_Locked
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Search Terms: ");
            var entries = EntrezHandler.GetInstance().Search(Console.ReadLine());
            foreach (var response in PubTatorHandler.GetInstance().GetArticleByPmId(entries))
            {
                
            }

            PubTatorHandler.GetInstance().GetArticleByPmId(entries);
            Console.WriteLine();
        }
    }
}