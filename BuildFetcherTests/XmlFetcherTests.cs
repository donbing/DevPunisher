using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildFetcher;
using System.Xml.Linq;

namespace BuildFetcher.Tests
{
    [TestClass]
    public class XmlFetcherTests
    {
        private string JobName = "ruby";

        [TestMethod]
        public void ShouldFetchJobXmlFromJobName()
        {
            var xmlFetcher = new HudsonXmlFetcher();

            XDocument xmlDoc = xmlFetcher.GetJobXmlFor(JobName); 

            Assert.IsNotNull(xmlDoc);
        }

        [TestMethod]
        [Ignore]
        public void ShouldFetchBuildXmlFromBuildNumberAndJobName()
        {
            // dont know build number to access so ignoring this one for now
            var xmlFetcher = new HudsonXmlFetcher();

            XDocument xmlDoc = xmlFetcher.GetBuildXmlFor(JobName, 3406);

            Assert.IsNotNull(xmlDoc);
        }
    }
}
