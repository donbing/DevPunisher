using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Build_Fetcher;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace Build_Fetcher.Tests
{
    [TestClass]
    public class JobMapperTests
    {
        [TestMethod]
        public void ShouldParseJobNumber()
        {
            XDocument xmlDoc = TestHelper.TrunkBuilderJobXml;

            Job currentJob = new JobMapper().CreateJobFrom(xmlDoc);

            Assert.AreEqual(2183, currentJob.LastBuildNumber);
        }
    }
}
