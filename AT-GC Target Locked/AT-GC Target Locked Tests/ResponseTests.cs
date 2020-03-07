using System;
using AT_GC_Target_Locked.Io;
using AT_GC_Target_Locked.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AT_GC_Target_Locked_Tests
{
    [TestClass]
    public class ResponseTests
    {
        [TestMethod]
        public void EnsureBadCodeDoesntBreak()
        {
            try
            {
                PubTatorHandler.GetInstance().GetArticleByPmId("fdsfds");
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EnsureCorrectParseLogic()
        {
            Assert.AreEqual("Disease", Annotation.ParseString("{\n          \"id\": \"2\",\n          \"infons\": " +
                                                              "{\n            \"identifier\": \"MESH:C537500\",\n" +
                                                              "            \"type\": \"Disease\"\n          },\n " +
                                                              "         \"text\": \"striatal degeneration\",\n  " +
                                                              "        \"locations\": [\n            {\n           " +
                                                              "   \"offset\": 19,\n              \"length\": 21\n      " +
                                                              "      }\n          ]\n        }").Infons["type"]);
        }
    }
}