using System;
using System.Linq;
using AT_GC_Target_Locked.Io;
using AT_GC_Target_Locked.Models;
using AT_GC_Target_Locked.Models.PubTator;
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

        [TestMethod]
        public void GeneralTotalParseTest()
        {
            var text = System.IO.File.ReadAllText("testResponse.json");
            var response = PubTatorResponse.ParseString(text);
            Assert.AreEqual("20085714", response.Id);
            Assert.AreEqual(2010, response.Year);
            Assert.IsTrue(response.Created.Equals(DateTimeOffset.FromUnixTimeMilliseconds(1572526582545)
                .DateTime));
        }

        [TestMethod]
        public void PassageParseTest()
        {
            var text = System.IO.File.ReadAllText("testResponse.json");
            var response = PubTatorResponse.ParseString(text);
            Assert.IsTrue(response.Passages.Any(passage => passage.Offset == 99));
        }

        [TestMethod]
        public void AuthorsParseTest()
        {
            var text = System.IO.File.ReadAllText("testResponse.json");
            var response = PubTatorResponse.ParseString(text);
            Assert.IsTrue(response.Authors.Any(s => s.Contains("Halfter")));
        }

        [TestMethod]
        public void TagParseTest()
        {
            var text = System.IO.File.ReadAllText("testResponse.json");
            var response = PubTatorResponse.ParseString(text);
            Assert.IsTrue(response.Tags.Any(tag => tag.data == "8622" && tag.tag == Tag.Gene));
        }
    }
}