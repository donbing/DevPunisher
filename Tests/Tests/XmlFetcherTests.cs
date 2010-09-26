using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using BuildFetcher;

namespace BuildFetcher.Tests.Integration
{
    [TestClass]
    public class XmlFetcherTests
    {
        private string JobName = "TrunkBuilder";

        [TestMethod]
        public void ShouldFetchJobXmlFromJobName()
        {
            var xmlFetcher = new HudsonXmlFetcher();

            XDocument xmlDoc = xmlFetcher.GetJobXmlFor(JobName); 

            Assert.IsNotNull(xmlDoc);
        }

        [TestMethod]
        public void ShouldFetchBuildXmlFromBuildNumberAndJobName()
        {
            var xmlFetcher = new HudsonXmlFetcher();

            XDocument xmlDoc = xmlFetcher.GetBuildXmlFor(JobName, 3406);

            Assert.IsNotNull(xmlDoc);
        }
    }
}
