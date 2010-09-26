using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using BuildFetcher;
using System.Reflection;
using System.Xml;

namespace BuildFetcher.Tests
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
