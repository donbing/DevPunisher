using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;

namespace Build_Fetcher.Tests
{
    public static class TestHelper
    {
        private static Assembly testAssembly = Assembly.GetAssembly(typeof(Build_Fetcher.Tests.TestHelper));

        public static XDocument SuccessfullBuildXml = GetXmlResource("successfullBuild");
        public static XDocument TrunkBuilderJobXml = GetXmlResource("TrunkBuilderJob");
        public static XDocument AnonymousBuildXml = GetXmlResource("anonymousBuild");
        public static XDocument BuildingBuildXml = GetXmlResource("buildingBuild");
        public static XDocument FailedBuildXml = GetXmlResource("failedBuild");

        private static XDocument GetXmlResource(string resourceName)
        {
            var fullResourceName = string.Format("BuildFetcher.Tests.TestData.{0}.xml", resourceName);

            var JobXml = testAssembly.GetManifestResourceStream(fullResourceName);

            XDocument xmlDoc = XDocument.Load(XmlReader.Create(JobXml));

            return xmlDoc;
        }
    }
}
