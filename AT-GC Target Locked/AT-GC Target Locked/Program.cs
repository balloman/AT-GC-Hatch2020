//Created by Bernard Allotey at 11:40 AM Saturday

using System;
using AT_GC_Target_Locked.Io;

namespace AT_GC_Target_Locked
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = PubTatorHandler.GetInstance();
            var myInterface = handler.GetArticleByPmId("20085714");
        }
    }
}